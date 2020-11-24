using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Stadsarkiv.Domain
{
    [Serializable, XmlType("table")]
    public class Table
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("folder")]
        public string Folder { get; set; }
        [XmlElement("description")]
        public string Description { get; set; }
        [XmlArray("columns")]
        public List<Column> Columns { get; set; }
    }
}