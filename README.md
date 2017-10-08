# 18app-dotnet-sdk
.NET SDK for developing applications which accept 18app vouchers (retails and stores).

## Esempio

```
var codice = "abcdefg";
var voucher = new Voucher { Codice = codice };
var result = await voucher.VerificaAsync();
result = await voucher.ImpegnaAsync();
var res = await voucher.ConfermaAsync(1.0);
if (res)
    Console.WriteLine("Successo :-)");
```


## Roadmap

Stato:

* [x] Api
* [x] Documentazione inline
* [x] Applicazione di esempio
* [ ] Interprete per i soap fault.
* [x] Documentazione markdown e README
* [ ] Test estensivi
* [ ] Pacchetto Nuget

## Commenti

Installare i due `.cer` come Trusted CA in Local Machine;  
Installare il p12 di prova come Personal in Local Machine;  
Far girare Visual Studio (o la app) come Amministratore
