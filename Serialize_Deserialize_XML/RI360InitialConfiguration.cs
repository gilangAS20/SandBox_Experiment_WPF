using System.Xml.Serialization;

namespace Serialize_Deserialize_XML;

[XmlType( TypeName = "Ri360PsrModule" )]
public class RI360InitialConfiguration
{
    public string robotID { get; set; }
    public string robotName { get; set; }
    public string robotEmail { get; set; }
}