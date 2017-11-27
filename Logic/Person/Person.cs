using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    [Serializable]
    public class Person : IDeserializationCallback
    {
        private string name, address, phoneNumber;
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }

        private string[] recordDate;
        public string[] RecordDate { get => recordDate; set => recordDate = value; }

        [NonSerialized] private static int counter = 1;
        [NonSerialized] private int serialNumber;
        public int SerialNumber { get => serialNumber; set => serialNumber = value; }

        private Person()
        {

        }

        public Person(string name, string address, string phone)
        {
            Name = name;
            Address = address;
            PhoneNumber = phone;
            SerialNumber = counter;
            RecordDate = new DateTime().GetDateTimeFormats();
            counter++;
        }

        public void Serialize()
        {
            string fileName = "person" + SerialNumber + ".dat";
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, this);
            }
        }

        public static Person Deserialize(int index)
        {
            Person person;
            string fileName = "person" + index + ".dat";
            IFormatter formatter = new BinaryFormatter();
            try
            {
                using (Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    person = (Person)formatter.Deserialize(stream);
                }
            } catch (Exception)
            {
                person = new Person();
            }
            //person.serialNumber = index;
            return person;
        }

        public void OnDeserialization(object sender)
        {
           /* string a = sender as string;
            Console.WriteLine(a);
            Console.WriteLine("ON DES");*/
        }
        public static int GetLastIndex()
        {
            int index = 99;
            while (!File.Exists("person" + index + ".dat"))
            {
                index--;
            }
            return index;
        }
    }
}
