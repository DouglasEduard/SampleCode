using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Vidly2.Models;

namespace Vidly2.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name!")]
        [StringLength(255)]
        public string Name { get; set; }

        public byte MembershipTypeId { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        [Min18yearsifAMember]
        public Nullable<DateTime> Birthdate { get; set; }

        public string Operation { get; set; }
    }
}