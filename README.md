# SomeValidation library for .NET C#
**Contributions and functionality additions to the project are welcome**

*place star if this lib was helpful!*

**this library contains some methods what resolves popular problems of validation, easy names for methods, easy to start**

### Some examples with data types

`IsValidEmail(string)`

`IsValidPhone(string)`

`IsValidPassword(string, int minLength)`*also checking for some bad symbols*

`IsValidGuid(string)`

`IsValidIPv6(string) & IsValidIPv4(string)`

`IsFileSizeValid(string filePath, string sizeWithUnit)` *accepting second string "b" bytes, "kb" - kilobytes, "mb" - megabytes, "gb" - gigabytes*

`IsSafeXSS(string)`

`IsValidVIN(string)`

`IsValidCardNumber(string)`

`IsValidMD5(string)`

*and lot more*
---
# Some examples to usage

```C#
string uuid = "550e8400-e29b-41d4-a716-446655440000"; 
Console.WriteLine(UUIDValidator.IsValidUUID(uuid));
```
```C#
string cardNumber = "4539 1488 0343 6467";
Console.WriteLine(CardValidator.IsValidCardNumber(cardNumber));
```
```C#
// Zone: Europe as example
double minLatitude = 35.0;
double maxLatitude = 71.0;
double minLongitude = -25.0;
double maxLongitude = 40.0;

Console.WriteLine(IsInZone(50.0, 10.0, minLatitude, maxLatitude, minLongitude, maxLongitude));  // True
Console.WriteLine(IsInZone(10.0, 10.0, minLatitude, maxLatitude, minLongitude, maxLongitude));  // False
Console.WriteLine(IsInZone(50.0, -30.0, minLatitude, maxLatitude, minLongitude, maxLongitude)); // False 
```
