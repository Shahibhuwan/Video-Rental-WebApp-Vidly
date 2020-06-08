using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType>MembershipTypes{ get; set;} //using Ienumerable making this code loosley coupled because Ienumerable is gernal collection that can deal with list operation and many others
        public Customer Customer { get; set; }
    }
}