using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientsPolicies.Models
{
    public class Policies
    {
        public string Id { get; set; }
        public double AmountInsured { get; set; }
        public string Email { get; set; }
        public string InceptionDate { get; set; }
        public bool InstallmentPayment { get; set; }
        public string ClientId { get; set; }
    }
}
