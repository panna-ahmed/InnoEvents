using System.Runtime.Serialization;

namespace InnoEvents.DTOs
{
    public class Address
    {
        [DataMember(Name = "street")]
        public string Street { get; set; }
        [DataMember(Name = "suite")]
        public string Suite { get; set; }
        [DataMember(Name = "city")]
        public string City { get; set; }
        [DataMember(Name = "zipcode")]
        public string Zipcode { get; set; }
        [DataMember(Name = "geo")]
        public Geo Geo { get; set; }
    }

    public class Company
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "catchPhrase")]
        public string CatchPhrase { get; set; }
        [DataMember(Name = "bs")]
        public string Bs { get; set; }
    }

    public class Geo
    {
        [DataMember(Name = "lat")]
        public string Lat { get; set; }
        [DataMember(Name = "lng")]
        public string Lng { get; set; }
    }

    public class User
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "username")]
        public string Username { get; set; }
        [DataMember(Name = "email")]
        public string Email { get; set; }
        [DataMember(Name = "address")]
        public Address Address { get; set; }
        [DataMember(Name = "phone")]
        public string Phone { get; set; }
        [DataMember(Name = "website")]
        public string Website { get; set; }
        [DataMember(Name = "company")]
        public Company Company { get; set; }
    }
}
