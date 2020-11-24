using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Stadsarkiv.Domain
{
    [Serializable, XmlRoot(Namespace = "http://www.sa.dk/xmlns/diark/1.0", ElementName ="siardDiark")]
    public class TableIndex
    {
        [XmlElement("dbName")]
        public string DbName { get; set; }
        [XmlElement("databaseProduct")]
        public string DatabaseProduct { get; set; }
        [XmlArray("tables")]
        public List<Table> Tables { get; set; }
    }
}
