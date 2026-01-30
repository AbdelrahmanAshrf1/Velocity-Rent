using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityRent.Entities
{
    public class Address
    {
        public int ID { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public string Country { get; private set; }
        public decimal Latitude { get; private set; }
        public decimal Longitude { get; private set; }
        public bool IsActive { get; private set; }

        public Address(string city, string state, string zipCode,string country, decimal latitude, decimal longitude)
        {
            City = city;
            State = state;
            ZipCode = zipCode;
            Country = country;
            Latitude = latitude;
            Longitude = longitude;
            IsActive = true;
        }
        public void Update(string city, string state, string zipCode, string country, decimal latitude, decimal longitude)
        {
            City = city;
            State = state;
            ZipCode = zipCode;
            Country = country;
            Latitude = latitude;
            Longitude = longitude;
        }
    }

}
