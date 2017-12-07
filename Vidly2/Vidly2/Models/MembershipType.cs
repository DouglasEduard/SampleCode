using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
    }
}