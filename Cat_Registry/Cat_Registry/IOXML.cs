using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using static Cat_Database.Program;
using static Cat_Database.Cat;


namespace Cat_Database
{
    public  class IOXML : ISaveLoadable
    {
        public static string fileName = "CatsData.xml";

        public  void Save()
        {
            XmlTextWriter writer = new XmlTextWriter(fileName, Encoding.Unicode);
            writer.WriteStartDocument();
            writer.WriteStartElement("Cats");
            WriteObjectsData(writer);
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        private static void WriteObjectsData(XmlTextWriter writer)
        {
            foreach (var obj in collection)
            {
                writer.WriteStartElement("Cat");
                writer.WriteAttributeString("Name", obj.name);
                writer.WriteAttributeString("Breed", obj.breed);
                writer.WriteAttributeString("Color", obj.color);
                writer.WriteAttributeString("Age", obj.age.ToString());
                writer.WriteAttributeString("Weight", obj.weight.ToString().Replace(',', '.'));
                writer.WriteEndElement();
            }
        }

        public  void Load()
        {
            if (!File.Exists(fileName)) return;
            XmlTextReader reader = new XmlTextReader(fileName)
            {
                WhitespaceHandling = WhitespaceHandling.None
            };
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "Cat")
                    {
                        ReadObjectData(reader);
                    }
                }
            }
            reader.Close();
        }

        private static void ReadObjectData(XmlTextReader reader)
        {
            Cat obj = new Cat()
            {
                name = reader.GetAttribute("Name"),
                breed = reader.GetAttribute("Breed"),
                color = reader.GetAttribute("Color"),
                age = int.TryParse(reader.GetAttribute("Age"), out int _age) ? (int?)_age : null,
                weight = decimal.TryParse(reader.GetAttribute("Weight").Replace('.', ','), out decimal _weight) ? (double?)_weight : null
            };

            collection.Add(obj);
        }
    }
}
