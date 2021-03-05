using System;
using System.Collections.Generic;
using System.Text;

namespace KNGSHV.Application.ViewModels
{
    public class ContactViewModel
    {
        public Guid Id { get; set; }

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
