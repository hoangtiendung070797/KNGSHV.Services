using KNGSHV.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace KNGSHV.Data.Entities
{
    public class Contact : DomainEntity<Guid>
    {
        public Contact() { }

        public Contact(Guid id, string name, string phone, string email,
            string website, string address, string other, double? longtitude, double? latitude)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Email = email;
            Website = website;
            Address = address;
            Other = other;
            Lng = longtitude;
            Lat = latitude;
        }

        public string Name { set; get; }

        public string Phone { set; get; }

        public string Email { set; get; }

        public string Website { set; get; }

        public string Logo { get; set; }

        public string CoverImage { get; set; }

        public string Address { set; get; }

        public string Other { set; get; }

        public double? Lat { set; get; }

        public double? Lng { set; get; }
    }
}
