using CountryManagement.DataAccess.Context;
using CountryManagement.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryManagement.DataAccess.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CountryManagementDbContext _context;
        public UnitOfWork(CountryManagementDbContext context)
        {
            _context = context;
            Country = new CountryRepository(_context);
        }

        public ICountryRepository Country { get; private set; }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
