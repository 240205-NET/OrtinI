using System;
using System.IO;

namespace Serializer {

    public class Program {

        public static void Main (string[] args) {
            Console.WriteLine("Serializer running...");

            Person LongJohn = new Person("LongJohn", 72, 22);

            Console.WriteLine(LongJohn.ToString());

            string[] text = {"Hello there everyone.", "We're making an array of Strings."};
            string path = @".\TextFile.txt";
            if (File.Exists(path)) {
                //Console.WriteLine("Yup, found it.");
                File.AppendAllLines(path, text);
            }
            else {
                File.WriteAllLines(path, text);
            }

            if (File.Exists(path)) {
                string[] readText = File.ReadAllLines(path);
                foreach (string s in readText) {
                    Console.WriteLine(s);
                }
            }
            else {
                Console.WriteLine("File not found!");
            }

            Console.WriteLine(LongJohn.SerializeXML());

            string[] text1 = {LongJohn.SerializeXML()};
            File.WriteAllLines(path, text1);

            Menu();
        }

        private static void Menu () {
            bool exit = false;
            int menuSelection = -1;
            do {
                Console.WriteLine("1. Read from file.");
                Console.WriteLine("2. Write from file.");
                Console.WriteLine("3. Serialize person to XML (and write it to file).");
                Console.WriteLine("4. Deserialize person from XML file.");
                Console.WriteLine("5. Exit program.");
                try {
                    menuSelection = Int32.Parse(Console.ReadLine());
                }
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("The value you entered was not valid. Please try again.");
                }
                switch (menuSelection) {
                    case 1:
                        // Read from file
                        break;
                    case 4:
                        // Read from file then deserialize to an object
                        break;
                    case 3:
                        // Serialize to XML then write to file
                    case 2:
                        // Write to file
                        break;
                    case 5:
                        Console.WriteLine("You have chosen to quit. Exiting...");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("The value you entered does not match any of the menu options. Please try again.");
                        break;
                }
            } while (!exit);
        }

    }

}