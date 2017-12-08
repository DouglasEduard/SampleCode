using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly2.Models;

namespace Vidly2.ViewModels
{
    public class CustomerDetail
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        [Display(Name = "Birth of Date")]
        public Nullable<DateTime> Birthdate { get; set; }

        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public string Operation { get; set; }
    }
}