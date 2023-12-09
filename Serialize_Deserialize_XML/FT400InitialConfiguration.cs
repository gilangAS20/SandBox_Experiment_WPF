using System.Xml.Serialization;

namespace Serialize_Deserialize_XML;

[XmlType( TypeName = "Ft400PsrModule" )]
public class FT400InitialConfiguration
{
    public string robotID { get; set; }
    public string robotName { get; set; }
    public string robotEmail { get; set; }
}