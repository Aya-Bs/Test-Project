using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Helpers
{
    public interface IJWTTokenGenerator
    {
        string GenerateToken(User user, DateTime expDate, bool isSubscriber);

    }
}
