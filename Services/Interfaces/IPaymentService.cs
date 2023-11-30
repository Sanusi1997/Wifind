using System;
using WiFind.Entities;

namespace WiFind.Services.Interfaces
{
    public interface IPaymentService
    {
        Payment AddPayment(Payment payment);
        Task<Payment> Update(Payment payment);
    }
}

