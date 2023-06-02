using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository  subscriptionRepository ;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            this.subscriptionRepository = subscriptionRepository;
        }

        public async Task<Subscriber> CreateAsync(Subscriber subscription)
        {
           return await subscriptionRepository.CreateAsync(subscription);
        }

        public async Task DeleteAsync(Subscriber subscription)
        {
            await subscriptionRepository.DeleteAsync(subscription);
        }

        public async Task<IEnumerable<Subscriber>> GetAsync()
        {
           return await subscriptionRepository.GetAsync();
        }

        public async Task<Subscriber> GetByCustomerIdAsync(string id)
        {
            return await subscriptionRepository.GetByCustomerIdAsync(id);

        }
        public async Task<Subscriber> GetByIdAsync(string id)
        {
            return await subscriptionRepository.GetByIdAsync(id);
        }

        public async Task<Subscriber> UpdateAsync(Subscriber subscription)
        {
            return await subscriptionRepository.UpdateAsync(subscription);
        }
    }
}
