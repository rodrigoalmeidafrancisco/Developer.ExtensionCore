> # ToByte

* Converte uma string ou object ou Enum em byte, caso não consiga converter retorna 0. 

```csharp
string val = "5";
byte valReturn = val.ToByte(); /* 5 */
byte valReturn = ByteExtension.ToByte(val); /* 5 */

string val = "Teste";
byte valReturn = val.ToByte(); /* 0 */
byte valReturn = ByteExtension.ToByte(val); /* 0 */
```

> # ImageScale

* Converte os bytes de uma imagem na escala desejada, caso o valor esteja null ou não consiga converter, irá retornar null. 

```csharp
byte[] valReturn = val.ImageScale(2); 
byte[] valReturn = ByteExtension.ImageScale(val, 2); 
```

> # ToPathByteArray

* Através do caminho passado, ele obtém o arquivo e converte em byte[], caso o caminho esteja nulo ou vazio ou somente com espaço ou não consiga converter ou localizar o arquivo, irá retornar null. 

```csharp
byte[] valReturn = val.ToPathByteArray(); 
byte[] valReturn = ByteExtension.ToPathByteArray(val);
```