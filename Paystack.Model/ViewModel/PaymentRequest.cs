using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paystack.Model.ViewModel
{
    public class PaymentRequest
    {
        public string Email { get; set; }
        public decimal Amount { get; set; }
    }
}
