namespace Italia.Voucher18App
{
    public class VerificaVoucherResult
    {
        VerificaVoucher.CheckResponse response;

        /// <summary>
        /// cinema, teatro, libreria…
        /// </summary>
        public string Ambito => response.ambito;

        /// <summary>
        /// libri, spettacoli…
        /// </summary>
        public string Bene => response.bene;

        /// <summary>
        /// importo totale del voucher
        /// </summary>
        public double Importo => response.importo;

        /// <summary>
        /// CF o Nome e Cognome
        /// </summary>
        public string NominativoBeneficiario => response.nominativoBeneficiario;

        /// <summary>
        /// partita IVA esercente
        /// </summary>
        public string PartitaIvaEsercente => response.partitaIvaEsercente;

        public VerificaVoucherResult(VerificaVoucher.CheckResponse response)
        {
            this.response = response;
        }
    }
}
