> # ToDateTime

* Converte uma string em DateTime, caso não consiga converter, retorna DateTime.MinValue. 

```csharp
string val = "25/02/2021";
DateTime valReturn = val.ToDateTime("pt-BR"); /* 25/02/2021 00:00:00 */
DateTime valReturn = DateTimeExtension.ToDateTime(val, "pt-BR"); /* 25/02/2021 00:00:00 */

string val = "25/02/2021 18:30:20";
DateTime valReturn = val.ToDateTime("pt-BR"); /* 25/02/2021 18:30:20 */
DateTime valReturn = DateTimeExtension.ToDateTime(val, "pt-BR"); /* 25/02/2021 18:30:20 */
```

> # ToDateTimeNull

* Converte uma string em DateTime?, caso não consiga converter, retorna NULL. 

```csharp
string val = "25/02/2021";
DateTime valReturn = val.ToDateTimeNull("pt-BR"); /* 25/02/2021 00:00:00 */
DateTime valReturn = DateTimeExtension.ToDateTimeNull(val, "pt-BR"); /* 25/02/2021 00:00:00 */

string val = "99/99/9999";
DateTime valReturn = val.ToDateTimeNull("pt-BR"); /* NULL */
DateTime valReturn = DateTimeExtension.ToDateTimeNull(val, "pt-BR"); /* NULL */
```

> # ToDateTimeDayEnd(this DateTime val)

* Adiciona 1 dia e diminui 1 milissegundo, fazendo com que a data fique no último dia e minuto do dia informado, conforme exemplo abaixo:
* OBS: Caso ocorra algum erro, retorna DateTime.MaxValue.

```csharp
string val = "25/02/2021";
DateTime valReturn = val.ToDateTimeDayEnd(); /* 25/02/2021 23:59:99:9999 */
DateTime valReturn = DateTimeExtension.ToDateTimeDayEnd(val); /* 25/02/2021 23:59:99:9999 */
```

> # ToDateTimeDayEnd(this DateTime? val) 

* Adiciona 1 dia e diminui 1 milissegundo, fazendo com que a data fique no último dia e minuto do dia informado, conforme exemplo abaixo:
* OBS: Caso ocorra algum erro, retorna DateTime.MaxValue.

```csharp
string val = "25/02/2021";
DateTime valReturn = val.ToDateTimeDayEnd(); /* 25/02/2021 23:59:99:9999 */
DateTime valReturn = DateTimeExtension.ToDateTimeDayEnd(val); /* 25/02/2021 23:59:99:9999 */
```