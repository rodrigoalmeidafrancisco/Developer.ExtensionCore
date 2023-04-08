> # ToDouble

* Converte uma string em double, caso não consiga converter, retorna double.MinValue (-1.7976931348623157E+308). 

```csharp
string val = "52,8725945";
double valReturn = val.ToDouble(); /* 52.8725945 */
double valReturn = DoubleExtension.ToDouble(val); /* 52.8725945 */

string val = long.MaxValue.ToString();
double valReturn = val.ToDouble(); /* 9.2233720368547758E+18 */
double valReturn = DoubleExtension.ToDouble(val); /* 9.2233720368547758E+18 */
```