using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface ISubscriptionService
    {
        Task<Subscriber> UpdateAsync(Subscriber subscription);
        Task<IEnumerable<Subscriber>> GetAsync();
        Task<Subscriber> GetByIdAsync(string id);
        Task<Subscriber> GetByCustomerIdAsync(string id);
        Task<Subscriber> CreateAsync(Subscriber subscription);
        Task DeleteAsync(Subscriber subscription);
    }
}
