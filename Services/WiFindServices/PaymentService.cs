using System;
using WiFind.Data;
using WiFind.Entities;
using WiFind.Services.Interfaces;

namespace WiFind.Services.WiFindServices
{
    public class PaymentService : IPaymentService
    {
        private readonly WiFindDbContext _context;
        public PaymentService(WiFindDbContext context)
        {
            _context = context;
        }

        public Payment AddPayment(Payment payment)
        {
            if (payment == null)
            {
                throw new ArgumentNullException(nameof(payment));
            }
            // the repository fills the id (instead of using identity columns)
            payment.PaymentId = Guid.NewGuid();
            payment.DateTimeCreated = DateTime.UtcNow;
            payment.IsVerified = true;
            _context.Payments.Add(payment);
            _context.SaveChanges();
            return payment;
        }

        public Task<Payment> Update(Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}

