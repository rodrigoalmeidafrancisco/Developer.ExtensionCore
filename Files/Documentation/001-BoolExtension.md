> # IsBetween

* Verifica se o um valor está entre um intervalo, valido para: **_DateTime, int, long, decimal, float, double, TimeSpan_**.

```csharp
DateTime val = DateTime.Now;
bool valReturn = val.IsBetween(DateTime.Now.AddMinutes(-5), DateTime.Now.AddMinutes(5)); /* true */
bool valReturn = BoolExtension.IsBetween(val, DateTime.Now.AddMinutes(-5), DateTime.Now.AddMinutes(5)); /* true */
```

> # IsNullOrEmpty

* Verifica se uma string é nula ou vazia.

```csharp
string val = null;
bool valReturn = val.IsNullOrEmpty(); /* true */
bool valReturn = BoolExtension.IsNullOrEmpty(val); /* true */

string val = "Teste";
bool valReturn = val.IsNullOrEmpty(); /* false */
bool valReturn = BoolExtension.IsNullOrEmpty(val); /* false */
```

> # IsNullOrWhiteSpace

* Verifica se uma string é nula ou contém apenas espaço.

```csharp
string val = null;
bool valReturn = val.IsNullOrWhiteSpace(); /* true */
bool valReturn = BoolExtension.IsNullOrWhiteSpace(val); /* true */

string val = "  ";
bool valReturn = val.IsNullOrWhiteSpace(); /* true */
bool valReturn = BoolExtension.IsNullOrWhiteSpace(val); /* true */

string val = "Teste";
bool valReturn = val.IsNullOrWhiteSpace(); /* false */
bool valReturn = BoolExtension.IsNullOrWhiteSpace(val); /* false */
```

> # IsNullOrEmptyOrWhiteSpace

* Verifica se uma string é nula ou vazia ou contém apenas espaço.

```csharp
string val = null;
bool valReturn = val.IsNullOrEmptyOrWhiteSpace(); /* true */
bool valReturn = BoolExtension.IsNullOrEmptyOrWhiteSpace(val); /* true */

string val = "  ";
bool valReturn = val.IsNullOrEmptyOrWhiteSpace(); /* true */
bool valReturn = BoolExtension.IsNullOrEmptyOrWhiteSpace(val); /* true */

string val = "Teste";
bool valReturn = val.IsNullOrEmptyOrWhiteSpace(); /* false */
bool valReturn = BoolExtension.IsNullOrEmptyOrWhiteSpace(val); /* false */
```




