using System;
using System.Collections.Generic;

namespace Italia.Sdk18App
{
    public class CheckRequest
    {
        public List<Check> Checks { get; set; }
    }

    public class Check
    {
        public string TipoOperazione { get; set; }
        public string CodiceVoucher { get; set; }
        public string PartitaIvaEsercente { get; set; }
    }
}
