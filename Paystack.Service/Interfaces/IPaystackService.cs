using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paystack.Model.ViewModel;

namespace Paystack.Service.Interfaces
{
    public interface IPaystackService
    {
        Task<(string AuthorizationUrl, string Reference)> InitializePayment(PaymentRequest request);
        Task<bool> VerifyPayment(string reference);
    }
}
