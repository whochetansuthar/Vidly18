using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly18.Dtos
{
    public class MembershipTypeDto
    {
        public byte Id { get; set; }
        public string MembershipTypeName { get; set; }
        public byte Discount { get; set; }
        public byte DurationInMonth { get; set; }
        public byte SubscriptionCharge { get; set; }
    }
}