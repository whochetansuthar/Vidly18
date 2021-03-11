using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly18.Models;


namespace Vidly18.ViewModel
{
    public class CustomerVIewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
    }
}