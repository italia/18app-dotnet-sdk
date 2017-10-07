using System;
using System.Collections.Generic;

namespace Italia.Sdk18App
{
    public class CheckRequestObj
    {
        public Check CheckReq { get; set; }
    }

    public class Check
    {
        public string TipoOperazione { get; set; }
        public string CodiceVoucher { get; set; }
        public string PartitaIvaEsercente { get; set; }
    }

    public class CheckResponse
    {
        public string NominativoBeneficiario { get; set; }
        public string PartitaIvaEsercente { get; set; }
        public string Ambito { get; set; }
        public string Bene { get; set; }
        public double Importo { get; set; } // TODO: Cambiare a Decimal quando il WSDL e' corretto.
    }

    public class Confirm
    {
        public string TipoOperazione { get; set; }
        public string CodiceVoucher { get; set; }
        public double Importo { get; set; } // TODO: Cambiare a Decimal quando il WSDL e' corretto.
    }

    public class ConfirmResponse
    {
        public string Esito { get; set; }
    }

    public class CheckResponseObj
    {
        public CheckResponse CheckResp { get; set; }
    }

    public class ConfirmRequestObj
    {
        public Confirm CheckReq { get; set; }
    }

    public class ConfirmResponseObj
    {
        public ConfirmResponse CheckResp { get; set; }
    }
}