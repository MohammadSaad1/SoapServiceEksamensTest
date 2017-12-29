using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoapServiceEksamensTest
{
    [DataContract]
    public class Catch
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string navn { get; set; }

        [DataMember]
        public string art { get; set; }

        [DataMember]
        public int uge { get; set; }

        public Catch(int id, string navn, string art, int uge)
        {
            this.id = id;
            this.navn = navn;
            this.art = art;
            this.uge = uge;
        }
    }
}