using System.Net.Mail;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.IO;

namespace SomeValidation;

public static class Validator
{
    public static bool IsValidEmail(string email)
    {
        try
        {
            var mailAddress = new MailAddress(email);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }

    public static bool IsMinLength(int minLength, string stringToCheck)
    {
        if (stringToCheck.Length < minLength)
            return false;
        else 
            return true;
    }

    public static bool IsLengthInRange(int minLength, int maxLength, string stringToCheck)
    {
        if (stringToCheck.Length > minLength && stringToCheck.Length < maxLength)
            return true;
        else
            return false;
    }

    public static bool IsValidPhone(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
            return false;

        string pattern = @"^\+?[1-9]\d{7,14}$";
        return Regex.IsMatch(phone, pattern);
    }

    public static bool IsValidUrl(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
            return false;

        Uri result;
        return Uri.TryCreate(url, UriKind.Absolute, out result) &&
               (result.Scheme == Uri.UriSchemeHttp || result.Scheme == Uri.UriSchemeHttps);
    }

    public static bool IsValidPassword(string password, int minLength)
    {
        if (string.IsNullOrWhiteSpace(password) || password.Length < minLength)
            return false;

        return Regex.IsMatch(password, @"[a-z]") &&
               Regex.IsMatch(password, @"[A-Z]") &&
               Regex.IsMatch(password, @"\d") &&
               Regex.IsMatch(password, @"[^a-zA-Z\d]");
    }
    
    public static bool IsValidName(string name, List<char> invalidChars)
    {
        if (string.IsNullOrEmpty(name))
            return false;

        foreach (var ch in name)
        {
            if (invalidChars.Contains(ch))
                return false;
        }

        return true;
    }
    
    public static bool IsValidGuid(string guidString)
    {
        return Guid.TryParse(guidString, out _);
    }
    
    public static bool IsValidIPv4(string ipAddress)
    {
        string pattern = @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
        return Regex.IsMatch(ipAddress, pattern);
    }
    
    public static bool IsValidIPv6(string ipAddress)
    {
        string pattern = @"^([0-9a-fA-F]{1,4}:){7}[0-9a-fA-F]{1,4}$";
        return Regex.IsMatch(ipAddress, pattern);
    }
    
    public static bool IsValidFileExtension(string filePath, string[] validExtensions)
    {
        string fileExtension = Path.GetExtension(filePath).ToLower();

        foreach (var ext in validExtensions)
        {
            if (fileExtension.Equals("." + ext.ToLower()))
            {
                return true;
            }
        }

        return false;
    }
    
    public static bool IsFileSizeValid(string filePath, string sizeWithUnit)
    {
        long fileSize = new FileInfo(filePath).Length;
        
        string sizeUnit = sizeWithUnit.Substring(sizeWithUnit.Length - 2).ToLower(); 
        double sizeValue = Convert.ToDouble(sizeWithUnit.Substring(0, sizeWithUnit.Length - 2));
        
        long expectedSizeInBytes = sizeUnit switch
        {
            "b" => (long)sizeValue,
            "kb" => (long)(sizeValue * 1024), 
            "mb" => (long)(sizeValue * 1024 * 1024), 
            "gb" => (long)(sizeValue * 1024 * 1024 * 1024), 
            _ => throw new ArgumentException("Invalid size unit provided")
        };
        return fileSize <= expectedSizeInBytes;
    }
    
    public static bool IsValidBase64(string base64String)
    {
        if (string.IsNullOrWhiteSpace(base64String))
            return false;

        try
        {
            var bytes = Convert.FromBase64String(base64String);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }
    
    public static bool IsValidEnumValue<TEnum>(string value) where TEnum : Enum
    {
        return Enum.IsDefined(typeof(TEnum), value);
    }
    
    public static bool IsSafeSQL(string input)
    {
        if (string.IsNullOrEmpty(input))
            return true; 
        
        string pattern = @"(--)|(\b(select|insert|update|delete|drop|exec|sp_|xp_)\\b)|(')|(;)|(\bunion\b)|(\b--\b)|(\b/\*|\*/\b)|(\b--\b)|(\b%|\b$)|(\b\.\.)";
        
        return !Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase);
    }
    
    public static bool IsSafeXSS(string input)
    {
        if (string.IsNullOrEmpty(input))
            return true; 
        
        string pattern = @"<script.*?>.*?</script>|<style.*?>.*?</style>|<.*?on\w+="".*?""|<.*?>";
        
        return !Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
    }
    
    public static bool IsValidJwt(string token)
    {
        if (string.IsNullOrEmpty(token))
            return false;
        
        string pattern = @"^[A-Za-z0-9-_]+\.[A-Za-z0-9-_]+\.[A-Za-z0-9-_]+$";

        return Regex.IsMatch(token, pattern);
    }
    
    public static bool IsValidLatitude(double latitude)
    {
        return latitude >= -90 && latitude <= 90;
    }

    public static bool IsValidLongitude(double longitude)
    {
        return longitude >= -180 && longitude <= 180;
    }
    
    public static bool IsValidCoordinates(double latitude, double longitude)
    {
        return IsValidLatitude(latitude) && IsValidLongitude(longitude);
    }
    
    public static bool IsInCircularZone(double latitude, double longitude, double centerLatitude, double centerLongitude, double radiusKm)
    {
        double earthRadius = 6371;
        double latDistance = DegreeToRadian(latitude - centerLatitude);
        double lonDistance = DegreeToRadian(longitude - centerLongitude);
    
        double a = Math.Sin(latDistance / 2) * Math.Sin(latDistance / 2) +
                   Math.Cos(DegreeToRadian(centerLatitude)) * Math.Cos(DegreeToRadian(latitude)) *
                   Math.Sin(lonDistance / 2) * Math.Sin(lonDistance / 2);
        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        double distance = earthRadius * c;

        return distance <= radiusKm;
    }

    private static double DegreeToRadian(double degree)
    {
        return degree * (Math.PI / 180);
    }
    

    public static bool IsValidCountryCode(string countryCode)
    {
        return StaticValues.ValidCountryCodes.Contains(countryCode.ToUpper());
    }
    
    public static bool IsValidCurrencyCode(string currencyCode)
    {
        return StaticValues.ValidCurrencyCodes.Contains(currencyCode.ToUpper());
    }

    public static bool IsValidVIN(string vin)
    {
        if (vin.Length != 17)
            return false;
        
        if (vin.Contains('I') || vin.Contains('O') || vin.Contains('Q'))
            return false;
        
        if (!Regex.IsMatch(vin, @"^[A-HJ-NPR-Z0-9]{17}$"))
            return false;
        
        return IsValidCheckDigit(vin);
    }

    private static bool IsValidCheckDigit(string vin)
    {
        int sum = 0;

        for (int i = 0; i < 17; i++)
        {
            int value;
            char c = vin[i];

            if (Char.IsDigit(c))
                value = c - '0';
            else
                value = Array.IndexOf(StaticValues.VINValues, c.ToString());

            sum += value * StaticValues.VINWeights[i];
        }

        int remainder = sum % 11;
        char checkDigit = remainder == 10 ? 'X' : (char)('0' + remainder);

        return vin[8] == checkDigit;
    }
    
    public static bool IsValidCardNumber(string cardNumber)
    {
        cardNumber = cardNumber.Replace(" ", "");
        
        if (cardNumber.Length < 13 || cardNumber.Length > 19)
            return false;
        
        if (!long.TryParse(cardNumber, out _))
            return false;
        
        return CheckLuhn(cardNumber);
    }
    
    private static bool CheckLuhn(string cardNumber)
    {
        int sum = 0;
        bool isSecondDigit = false;
        
        for (int i = cardNumber.Length - 1; i >= 0; i--)
        {
            int digit = cardNumber[i] - '0';
            
            if (isSecondDigit)
            {
                digit *= 2;
                if (digit > 9)
                    digit -= 9;
            }
            
            sum += digit;
            isSecondDigit = !isSecondDigit;
        }
        
        return sum % 10 == 0;
    }
    
    public static bool IsValidMAC(string macAddress)
    {
        string pattern = @"^([0-9A-Fa-f]{2}[-:]){5}[0-9A-Fa-f]{2}$";
        
        return Regex.IsMatch(macAddress, pattern);
    }
    
    public static bool IsValidMD5(string hash)
    {
        string pattern = @"^[a-fA-F0-9]{32}$";
        return Regex.IsMatch(hash, pattern);
    }
    
    public static bool IsValidSHA256(string hash)
    {
        string pattern = @"^[a-fA-F0-9]{64}$";
        return Regex.IsMatch(hash, pattern);
    }

    public static bool IsValidHashtag(string hashtag)
    {
        if (string.IsNullOrWhiteSpace(hashtag))
            return false;

        return StaticValues.HashtagRegex.IsMatch(hashtag);
    }
    


    public static bool IsValidPassport(string country, string passportNumber)
    {
        if (StaticValues.PassportRegex.TryGetValue(country, out var regex))
        {
            return regex.IsMatch(passportNumber);
        }
        return false;
    }
}