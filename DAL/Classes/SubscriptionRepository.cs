using DAL.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly ApplicationDbContext _context;
        public SubscriptionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Subscriber> CreateAsync(Subscriber subscription)
        {
            await _context.Subscribers.AddAsync(subscription);
            await _context.SaveChangesAsync();
            return subscription;
        }

        public async Task DeleteAsync(Subscriber subscription)
        {
            _context.Subscribers.Remove(subscription);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Subscriber>> GetAsync()
        {
            return await _context.Subscribers.ToListAsync();
        }

        public async Task<Subscriber> GetByCustomerIdAsync(string id)
        {
            return await _context.Subscribers.SingleOrDefaultAsync(x => x.CustomerId == id);
        }

        public async Task<Subscriber> GetByIdAsync(string id)
        {
            return await _context.Subscribers.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Subscriber> UpdateAsync(Subscriber subscription)
        {
            _context.Subscribers.UpdateRange(subscription);
            await _context.SaveChangesAsync();
            return subscription;
        }
    }
}
