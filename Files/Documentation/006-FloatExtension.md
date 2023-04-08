> # ToFloat

* Converte uma string em float, caso não consiga converter, retorna float.MinValue (-3.40282347E+38). 

```csharp
string val = "41.00027357629127";
float valReturn = val.ToFloat(); /* 4.10002732E+15 */
float valReturn = FloatExtension.ToFloat(val); /* 4.10002732E+15 */
```