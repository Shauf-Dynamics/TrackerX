﻿using Microsoft.EntityFrameworkCore;
using TrackerX.Domain.Entities;
using TrackerX.Domain.Infrastructure;
using TrackerX.Domain.Infrastructure.Repositories;

namespace TrackerX.Domain.Data.Repositories
{
    public class RecordRepository : IRecordRepository
    {
        private readonly DataContext _context;

        public RecordRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Create(Record entity)
        {
            _context.Add(entity);

            await _context.SaveChangesAsync();
        }

        public async Task Update(Record entity)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Record>> GetAll()
        {
            throw new NotImplementedException();
        }


        public async Task<Record> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Record>> GetLastRecords(int amount, int userId)
        {
            return await _context.Records
                .Take(amount)
                .Where(x => !x.IsDeleted)
                .ToListAsync();            
        }

        public Task<Record> GetByUserId(int recordId, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
