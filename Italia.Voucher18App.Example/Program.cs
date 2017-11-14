using System;
using System.Threading.Tasks;

namespace Italia.Voucher18App.Example
{
	class Program
	{
		static async Task MainAsync()
		{
            Console.WriteLine("Inserisci codice buono: ");
            var codice = Console.ReadLine();
            var voucher = new Voucher { Codice = codice };
            var result = await voucher.VerificaAsync();
            Console.WriteLine($@"Esito verifica
Ambito:  {result.Ambito}
Bene:    {result.Bene}
Importo: {result.Importo}
Nome B.: {result.NominativoBeneficiario}
P. IVA:  {result.PartitaIvaEsercente}
");
            Console.WriteLine("Provo a scalare 1");
            result = await voucher.ImpegnaAsync();
            Console.WriteLine($@"Esito impegna
Ambito:  {result.Ambito}
Bene:    {result.Bene}
Importo: {result.Importo}
Nome B.: {result.NominativoBeneficiario}
P. IVA:  {result.PartitaIvaEsercente}
");
            var res = await voucher.ConfermaAsync(1);

            if (res)
                Console.WriteLine("Successo :-)");
            else
                Console.Write("Fallimento :-(");
        }

        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
            Console.ReadLine();
        }
    }
}
