// See https://aka.ms/new-console-template for more information
using System.IO;
using System.Linq;

using System.Xml.Serialization;
namespace Serialize_Deserialize_XML_List
{
    class Program
    {
        class Program
        {
            static void Main()
            {
                string folderPath = Console.ReadLine();
                if (Directory.Exists(folderPath))
                {
                    string[] xmlFiles = Directory.GetFiles(folderPath, "*.xml");

                    foreach (string xmlFile in xmlFiles)
                    {
                        Type objectType = DetectObjectType(xmlFile);
                        if (objectType != null)
                        {
                            object deserializedObject = DeserializeAObjectFromXML(xmlFile, objectType);
                            object deserializedObject = DeserializeAndLoadObjectFromXML<>()
                            // Lakukan sesuatu dengan objek yang telah di-deserialize di sini
                            Console.WriteLine($"Deserialized {objectType.Name}: {deserializedObject}");
                        }
                        else
                        {
                            Console.WriteLine($"Unsupported XML file: {xmlFile}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Folder tidak ditemukan.");
                }
            }

            static Type DetectObjectType(string xmlFilePath)
            {
                string xmlFileName = Path.GetFileName(xmlFilePath);
                if (xmlFileName.StartsWith("ri360config", StringComparison.OrdinalIgnoreCase))
                {
                    return typeof(RI360InitConfiguration);
                }
                else if (xmlFileName.StartsWith("ri360owner", StringComparison.OrdinalIgnoreCase))
                {
                    return typeof(RI360Owner);
                }
                else if (xmlFileName.StartsWith("ri360support", StringComparison.OrdinalIgnoreCase))
                {
                    return typeof(RI360Support);
                }
                // Tambahkan pengecekan untuk kelas lainnya di sini jika diperlukan.
                else
                {
                    return null; // Tidak mendukung kelas apa pun
                }
            }
        
        
        
        public static void SerializeAndWriteObjectToXML(Object obj, string fullPath)
        {
            var xmlSerializer = new XmlSerializer(obj.GetType());
            //using (var writer = new StreamWriter(fullPath))
            using( var stream = new MemoryStream())
            {
                //.....................((xml mau ditulis kemana), (apa yang mau ditulis))
                //xmlSerializer.Serialize(writer, obj);
                xmlSerializer.Serialize(stream, obj);
                File.WriteAllBytes(fullPath, stream.ToArray());
            }
        }

        public static T DeserializeAndLoadObjectFromXML<T>(string fullPath)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using (var reader = new StreamReader(fullPath))
            {
                return (T)xmlSerializer.Deserialize(reader);
            }
        }
    }
    
    [XmlType( TypeName = "Ri360PsrModule" )]
    public class RI360InitConfiguration
    {
        public string robotID { get; set; }
        public string robotName { get; set; }
        public string robotEmail { get; set; } 
    }
    
    [XmlType( TypeName = "Ri360owner" )]
    public class RI360Owner
    {
        public string ownerName { get; set; }
    }
    
    [XmlType( TypeName = "Ri360Support" )]
    public class RI360Support
    {
        public string supportName { get; set; }
    }
    
    //======================= class ft400
    
    [XmlType( TypeName = "Ft400PsrModule" )]
    public class Ft400InitConfiguration
    {
        public string robotID { get; set; }
        public string robotName { get; set; }
        public string robotEmail { get; set; } 
    }
    
    [XmlType( TypeName = "Ft400owner" )]
    public class Ft400Owner
    {
        public string ownerName { get; set; }
    }
    
    [XmlType( TypeName = "Ft400Support" )]
    public class Ft400Support
    {
        public string supportName { get; set; }
    }
}