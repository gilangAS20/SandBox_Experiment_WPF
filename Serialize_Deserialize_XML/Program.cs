// See https://aka.ms/new-console-template for more information
using System;
using System.Xml.Serialization;

namespace Serialize_Deserialize_XML
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("           ===FT400 MIGRATOR===");
            Console.WriteLine("===Migration Tool From FT400 to RI360===");
            //======================================================================
            
            /*
            var robot1 = new FT400InitialConfiguration()
            {
                robotID = "1",
                robotEmail = "robot1@gmail.com",
                robotName = "Imager 1"
            };
            */
            
            //========print hasil xml ke console========================
            //SerializeObjectToXML(robot1);
            //===============================================
            
            
            //=====write hasil xml ke sebuah file .xml====================
            /*
            Console.WriteLine("Masukkan file path tempat file config disimpan:");
            var filePath = Console.ReadLine();
            Console.WriteLine("Masukkan nama file untuk menyimpan hasil serialize");
            var fileName = Console.ReadLine();
            string fullPath = $"{filePath}\\{fileName}";
            Console.WriteLine("Full path-nya adalah: " + fullPath);
            
            SerializeAndWriteObjectToXML(robot1, fullPath);
            */
            //=======================================================================
            
            
            
            
            //=====Deserialize file xml==============================================
            
            Console.WriteLine("Masukkan file path tempat file config disimpan:");
            var filePath = Console.ReadLine();
            Console.WriteLine("Masukkan nama file yang ingin di-deserialize");
            var fileName = Console.ReadLine();
            string fullPath = $"{filePath}\\{fileName}";
            Console.WriteLine("Full path-nya adalah: " + fullPath);
            
            FT400InitialConfiguration deserializedRobot = DeserializeAndLoadObjectFromXML<FT400InitialConfiguration>(fullPath);
            var ft400robotIDvalue = deserializedRobot.robotID;
            var ft400robotEmailvalue = deserializedRobot.robotEmail;
            var ft400robotNamevalue = deserializedRobot.robotName;
            
            // Menampilkan objek yang telah di-deserialize ke layar
            Console.WriteLine("\nObjek yang telah di-deserialize:");
            Console.WriteLine($"robotID: {deserializedRobot.robotID}");
            Console.WriteLine($"robotEmail: {deserializedRobot.robotEmail}");
            Console.WriteLine($"robotName: {deserializedRobot.robotName}");
            
            Console.WriteLine($"{deserializedRobot.robotID} \n{deserializedRobot.robotEmail}\n {deserializedRobot.robotName}");
            
            //Mencoba copy value nya ke class RI360InitialConfiguration
            RI360InitialConfiguration ri360InitialConfiguration = new RI360InitialConfiguration();
            ri360InitialConfiguration.robotID = deserializedRobot.robotID;
            ri360InitialConfiguration.robotEmail = deserializedRobot.robotEmail;
            ri360InitialConfiguration.robotName = deserializedRobot.robotName;

            var FilePath = @"E:\Employee_Gilang\SandBox_Experiment\test_xml\test_xml_copyFromOtherConfigClass";
            var FileName = @"Ri360InitialConfiguration_CopyFrom_Ft400InitialConfiguration.xml";
            var FullPath = $"{FilePath}\\{FileName}";

            SerializeAndWriteObjectToXML(ri360InitialConfiguration, FullPath);
            //=======================================================================

            
            //=======================================================================
            Console.WriteLine("Press any key to stop the program...");
            Console.ReadKey();
            Console.WriteLine("Program closed...");
        }
 
        // menuliskan hasil xml menjadi string dan ditampilkan di console
        public static void SerializeObjectToXML(Object obj)
        {
            var xmlSerializer = new XmlSerializer(obj.GetType());
            using (var writer = new StringWriter())
            {
                xmlSerializer.Serialize(writer, obj);
                var xmlToString = writer.ToString();
                Console.WriteLine(xmlToString);
            }
        }
        
        // menuliskan hasil xml menjadi sebuah file xml
        // jika file belum ada maka file akan dibuat
        // jika sudah ada maka jika isinya baru akan ditimpa
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
}