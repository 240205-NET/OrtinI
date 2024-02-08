using System.Xml.Serialization;

namespace Serializer {

    public class Person {

        public string? name {get; set; }
        public double? height { get; set; }
        public int? age { get; set; }
        private XmlSerializer Serializer = new XmlSerializer(typeof(Person));

        public Person () {

        }

        public Person (string? name, double? height, int? age) {
            this.name = name;
            this.height = height;
            this.age = age;
        }

        public Person (string name, double height, int age) {
            this.name = name;
            this.height = height;
            this.age = age;
        }

        public string SerializeXML () {
            var stringWriter = new StringWriter();
            Serializer.Serialize(stringWriter, this);
            stringWriter.Close();
            return stringWriter.ToString();
        }

        public string ToString () {
            var result = new System.Text.StringBuilder();
            result.AppendLine($"Name: {this.name}\t Height: {this.height}in.\t Age: {this.age} yrs. old.");
            return result.ToString();
        }

    }

}