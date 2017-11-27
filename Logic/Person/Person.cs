using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    [Serializable]
    public class Person
    {
        private string name, address, phoneNumber;
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }

        private DateTime recordDate;
        public DateTime RecordDate { get => recordDate; set => recordDate = value; }

        [NonSerialized] private int serialNumber;
        public int SerialNumber { get => serialNumber; set => serialNumber = value; }

        public Person()
        {

        }
    }
}
