using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Prova.Core.Model
{
    [DataContract]
    public class Ordine
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public int ClienteID { get; set; }

        [DataMember]
        public DateTime DataOrdine { get; set; }

        [DataMember]
        public string CodiceOrdine { get; set; }

        [DataMember]
        public string CodiceProdotto { get; set; }

        [DataMember]
        public decimal? Importo { get; set; }

        public Cliente Cliente { get; set; }
    }
}
