using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IRecordRepository
    {
        Task<IEnumerable<Record>> GetLastRecords(int amount, int userId);
    }
}
