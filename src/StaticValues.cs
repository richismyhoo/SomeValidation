using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;

namespace SomeValidation;

public class StaticValues
{
    
    public static readonly Regex IsoDateRegex = new Regex(@"^\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01])$", RegexOptions.Compiled);
    
    public static readonly Dictionary<string, Regex> PassportRegex = new Dictionary<string, Regex>
    {
        { "USA", new Regex(@"^\d{9}$") },
        { "China", new Regex(@"^[EG]\d{8}$") },
        { "India", new Regex(@"^[A-Z]{1}\d{7}$") },
        { "Russia", new Regex(@"^\d{2} \d{2} \d{6}$") },
        { "Brazil", new Regex(@"^[A-Z]{2}\d{6}$") },
        { "Indonesia", new Regex(@"^[A-Z]\d{7}$") },
        { "Pakistan", new Regex(@"^[A-Z]{2}\d{7}$") },
        { "Nigeria", new Regex(@"^[A-Z]\d{8}$") },
        { "Bangladesh", new Regex(@"^[A-Z]\d{7}$") },
        { "Mexico", new Regex(@"^[A-Z]{2}\d{6}$") },
        { "Japan", new Regex(@"^[A-Z]{2}\d{7}$") },
        { "Ethiopia", new Regex(@"^\d{7}$") },
        { "Philippines", new Regex(@"^[A-Z]\d{7}$") },
        { "Egypt", new Regex(@"^[A-Z]\d{8}$") },
        { "Vietnam", new Regex(@"^\d{8,9}$") },
        { "DR Congo", new Regex(@"^[A-Z]{2}\d{7}$") },
        { "Turkey", new Regex(@"^\d{9}$") },
        { "Iran", new Regex(@"^[A-Z]{1}\d{8}$") },
        { "Germany", new Regex(@"^[CFGHJKLMNPRTVWXYZ0-9]{9}$") },
        { "France", new Regex(@"^\d{2}[A-Z]{2}\d{5}$") }
    };
    
    public static readonly HashSet<string> ValidCountryCodes = new HashSet<string>
    {
        "RU", "CA", "US", "CN", "BR", "AU", "IN", "AR", "KZ", "DZ",
        "CD", "GL", "SA", "MX", "ID", "SD", "LY", "IR", "MN", "PE"
    };
    
    public static readonly HashSet<string> ValidCurrencyCodes = new HashSet<string>
    {
        "RUB", "CAD", "USD", "CNY", "BRL", "AUD", "INR", "ARS", "KZT", "DZD",
        "CDF", "DKK", "SAR", "MXN", "IDR", "SDG", "LYD", "IRR", "MNT", "PEN"
    };
    
    public static readonly string[] VINValues = {
        "A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "L", "M", "N", "P", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
        "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" 
    };
    
    public static readonly int[] VINWeights = { 8, 7, 6, 5, 4, 3, 2, 10, 0, 9, 8, 7, 6, 5, 4, 3, 2 };
    
    public static readonly Regex HashtagRegex = new Regex(@"^#[a-zA-Z0-9_]{1,49}$", RegexOptions.Compiled);
}