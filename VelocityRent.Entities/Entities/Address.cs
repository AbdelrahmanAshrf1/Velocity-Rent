
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

        // Constructor for NEW Address
        public Address(
            string city,
            string state,
            string zipCode,
            string country,
            decimal latitude,
            decimal longitude
            )
        {
            City = city;
            State = state;
            ZipCode = zipCode;
            Country = country;
            Latitude = latitude;
            Longitude = longitude;
            IsActive = true;
        }

        // Constructor for EXISTING Address loaded from DB
        public Address(
            int id,
            string city,
            string state,
            string zipCode,
            string country,
            decimal latitude,
            decimal longitude,
            bool isActive)
             : this(
                 city,
                 state,
                 zipCode,
                 country,
                 latitude,
                 longitude)
        {
            ID = id;
            IsActive = isActive;
        }
        public void Update(
            string city,
            string state,
            string zipCode,
            string country,
            decimal latitude,
            decimal longitude)
        {
            City = city;
            State = state;
            ZipCode = zipCode;
            Country = country;
            Latitude = latitude;
            Longitude = longitude;
        }
        public void Deactivate()
        {
            if (!IsActive) return;
            IsActive = false;
        }

    }

}
