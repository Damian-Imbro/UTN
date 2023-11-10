using System.Xml.Serialization;

namespace XML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Auto auto = new Auto ("Ford", 2010);
            Persona persona = new Persona("Jorge", "aaa 123", 30, auto);
            //Persona persona = new Persona("Jorge", "aaa 123", 30);

            CrearArchivoXML(persona);
        }

        private static void CrearArchivoXML(Persona persona)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Persona));
            using (StringWriter sw = new StringWriter())
            {
                xml.Serialize(sw, persona);
                string xmlString = sw.ToString();
                Console.WriteLine(xmlString);
            }
        }
    }
}