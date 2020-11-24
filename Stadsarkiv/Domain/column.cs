using System;
using System.Xml.Serialization;

namespace Stadsarkiv.Domain
{
    [Serializable, XmlType("column")]
    public class Column
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("columnID")]
        public string ColumnID { get; set; }
        [XmlElement("type")]
        public string Type { get; set; }
        [XmlElement("typeOriginal")]
        public string TypeOriginal { get; set; }
        [XmlElement("nullable")]
        public string Nullable { get; set; }
        [XmlElement("description")]
        public string Description { get; set; }
    }
}