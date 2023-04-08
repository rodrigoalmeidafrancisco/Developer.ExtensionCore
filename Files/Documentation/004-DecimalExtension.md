> # ToDecimal

* Converte uma string em decimal, caso não consiga converter, retorna decimal.MinValue (-79228162514264337593543950335M). 

```csharp
string val = "892694,12";
decimal valReturn = val.ToDecimal(); /* 892694.12M */
decimal valReturn = DecimalExtension.ToDecimal(val); /* 892694.12M */

string val = "892 694,12";
decimal valReturn = val.ToDecimal(NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, "fr-FR"); /* 892694.12M */
decimal valReturn = DecimalExtension.ToDecimal(val, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, "fr-FR"); /* 892694.12M */
```