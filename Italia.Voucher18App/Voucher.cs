using System.Threading.Tasks;

namespace Italia.Voucher18App
{
    public class Voucher
    {
        /// <summary>
        /// Il codice da controllare o usare
        /// </summary>
        public string Codice { get; set; }

        /// <summary>
        /// La partita IVA dell'esercente
        /// </summary>
        public string PartitaIva { get; set; }

        private VerificaVoucher.VerificaVoucherClient client = new VerificaVoucher.VerificaVoucherClient();

        /// <summary>
        /// Ritorna informazioni sul borsellino senza consumare il voucher e quindi senza scalare l’importo dal borsellino del beneficiario
        /// </summary>
        /// <returns></returns>
        public async Task<VerificaVoucherResult> VerificaAsync()
        {
            return await CheckAsync("1");
        }

        /// <summary>
        /// Consuma direttamente l’importo del voucher, scalandolo dal borsellino del beneficiario, 
        /// e restituiscele informazioni previste da <see cref="Verifica"/>
        /// </summary>
        /// <returns></returns>
        public async Task<VerificaVoucherResult> ConsumaAsync()
        {
            return await CheckAsync("2");
        }

        /// <summary>
        /// Impegna l’importo del voucher
        /// congelandolo per il tempo necessario ad eseguire un controllo di disponibilità in magazzino o per
        /// altre situazioni specifiche.
        /// </summary>
        /// <returns></returns>
        public async Task<VerificaVoucherResult> ImpegnaAsync()
        {
            return await CheckAsync("3");
        }

        /// <summary>
        /// Consuma l'importo passato, rispetto all’importo totale del voucher, momentaneamente impegnato.
        /// </summary>
        /// <param name="importo">L'importo da rimuovere dal borsellino</param>
        /// <returns></returns>
        public async Task<bool> ConfermaAsync(double importo)
        {
            return await ConfirmAsync("1", importo) == "OK";
        }

        /// <summary>
        /// Esegue un operazione di "Check" specificando esplicitamente il tipo operazione
        /// </summary>
        /// <param name="tipoOperazione">Il tipo operazione come previsto dal servizio di supporto</param>
        /// <returns></returns>
        public async Task<VerificaVoucherResult> CheckAsync(string tipoOperazione)
        {
            var response = await client.CheckAsync(new VerificaVoucher.Check { codiceVoucher = Codice, tipoOperazione = tipoOperazione, partitaIvaEsercente = PartitaIva });
            if (response == null || response.checkResp == null) return null;
            return new VerificaVoucherResult(response.checkResp);
        }

        /// <summary>
        /// Esegue un'operazione di "Confirm" specificando esplicitamente il tipo operazione
        /// </summary>
        /// <param name="tipoOperazione">Il tipo operazione come previsto dal servizio di supporto</param>
        /// <param name="importo">L'importo da rimuovere dal borsellino</param>
        /// <returns></returns>
        public async Task<string> ConfirmAsync(string tipoOperazione, double importo)
        {
            var response = await client.ConfirmAsync(new VerificaVoucher.Confirm { codiceVoucher = Codice, tipoOperazione = tipoOperazione, importo = importo });
            return response?.checkResp?.esito;
        }

        /// <summary>
        /// Esegue la chiamata--one time--di attivazione del servizio per l'esercente.
        /// </summary>
        /// <param name="partitaIva">La partita Iva dell'esercente</param>
        /// <returns></returns>
        public async Task AttivazioneSistemaAsync(string partitaIva)
        {
            await client.CheckAsync(new VerificaVoucher.Check { codiceVoucher = "11aa22bb", tipoOperazione = "1", partitaIvaEsercente = partitaIva });
        }

        /// <summary>
        /// Ritorna informazioni sul borsellino senza consumare il voucher e quindi senza scalare l’importo dal borsellino del beneficiario
        /// </summary>
        /// <returns></returns>
        public VerificaVoucherResult Verifica()
        {
            return Check("1");
        }

        /// <summary>
        /// Consuma direttamente l’importo del voucher, scalandolo dal borsellino del beneficiario, 
        /// e restituiscele informazioni previste da <see cref="Verifica"/>
        /// </summary>
        /// <returns></returns>
        public VerificaVoucherResult Consuma()
        {
            return Check("2");
        }

        /// <summary>
        /// Impegna l’importo del voucher
        /// congelandolo per il tempo necessario ad eseguire un controllo di disponibilità in magazzino o per
        /// altre situazioni specifiche.
        /// </summary>
        /// <returns></returns>
        public VerificaVoucherResult Impegna()
        {
            return Check("3");
        }

        /// <summary>
        /// Consuma l'importo passato, rispetto all’importo totale del voucher, momentaneamente impegnato.
        /// </summary>
        /// <param name="importo">L'importo da rimuovere dal borsellino</param>
        /// <returns></returns>
        public bool Conferma(double importo)
        {
            return Confirm("1", importo) == "OK";
        }

        /// <summary>
        /// Esegue un operazione di "Check" specificando esplicitamente il tipo operazione
        /// </summary>
        /// <param name="tipoOperazione">Il tipo operazione come previsto dal servizio di supporto</param>
        /// <returns></returns>
        public VerificaVoucherResult Check(string tipoOperazione)
        {
            var response = client.Check(new VerificaVoucher.Check { codiceVoucher = Codice, tipoOperazione = tipoOperazione, partitaIvaEsercente = PartitaIva });
            if (response == null) return null;
            return new VerificaVoucherResult(response);
        }

        /// <summary>
        /// Esegue la chiamata--one time--di attivazione del servizio per l'esercente.
        /// </summary>
        /// <param name="partitaIva">La partita Iva dell'esercente</param>
        /// <returns></returns>
        public string Confirm(string tipoOperazione, double importo)
        {
            var response = client.Confirm(new VerificaVoucher.Confirm { codiceVoucher = Codice, tipoOperazione = tipoOperazione, importo = importo });
            return response?.esito;
        }

        public void AttivazioneSistema(string partitaIva)
        {
            client.Check(new VerificaVoucher.Check { codiceVoucher = "11aa22bb", tipoOperazione = "1", partitaIvaEsercente = partitaIva });
        }
    }
}
