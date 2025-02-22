# Documentation for library methods

### You can see available in latest version country codes and currency codes in /src/StaticValues.cs

```C#
IsValidEmail(string email) //checking email string for validity

IsValidIsoDate(string date)  //checking is iso date string correct

InRange(int value, int min, int max) //checking is number > min and < max

IsMinLength(int minLength, string stringToCheck) //checking is string length more than minimal requirement

IsLengthInRange(int min, int max, string toCheck) //check is string length > minLength and < maxLength

IsValidPhone(string phone) //check is phone number correct

IsValidUrl(string url) //check is string url 

IsValidPassword(string password, int minLength) //check is password more than minimal length, and doesnt contain bad symbols

IsValidName(string name, List<char> invalidChars) //check is name contains some bad symbols (you are choosing what symbols is bad in this case)

IsValidGuid(string guid) //well, check is Guid string is valid

IsValidIPv4(string ip) //check is it ipv4

IsValidIPv6(string ip) // check is it ipv6

IsValidFileExtension(string filePath, string[] extensions) //check is this file in some right extension

IsFileSizeValid(string filePath, string sizeWithUnit) // types of sizes - "b', "kb", "mb", "gb"

IsValidBase64(string base64String) //check is string valid base64 string

IsValidEnumValue(string value) // is string value correct part of enum

IsSafeSQL(string input) // check is string contains some sql injection symbols/words

IsSafeXSS(string input) // check is this string safe and doesnt contains xss attack 

IsValidJwt(string token) // check is this jwt token valid

IsValidLatitude(double) isValidLongitude(double) IsValidCoordinates(double latitude, double longitude) // check coordinates

IsInCircularZone(double latitude, double longitude, double centerLatitude, double centerLongitude, double radiusKm) // check is coords in circular zone

DegreeToRadian(double degree) // degree to radian

IsValidCountryCode(string countryCode) // check is this country code valid

IsValidCurrencyCode(string currencyCode) //check is this currency code valid

IsValidVIN(string vin) //check is string correct vin code

IsValidCardNumber(strign cardNumber) //check card number by Luhn algo

IsValidMAC(string mac) // is string valid mac address

IsValidMD5(string hash) // is string correct md5 hash

IsValidSHA256(string hash) // is string correct sha256 hash

IsValidHashtag(string hashtag) // is string valid hashtag format

IsValidPassport(string country, string passport) // check is passport correct for country
```
