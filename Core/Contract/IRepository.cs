using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contract
{
    public interface IRepository
    {
        Task<int> SaveChangesAsync();
    }
}
