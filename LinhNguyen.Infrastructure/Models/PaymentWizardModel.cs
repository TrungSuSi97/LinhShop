using LinhNguyen.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhNguyen.Infrastructure.Models
{
    public class PaymentWizardModel
    {
        public UserPaymentMethod PaymentType { get; set; }
        public ShippingMethod ShippingType { get; set; }
    }
}
