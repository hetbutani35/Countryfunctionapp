using CountryManagement.DataAccess.Context;
using CountryManagement.Domain.Entities;
using CountryManagement.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryManagement.DataAccess.Implementation
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(CountryManagementDbContext context) : base(context)
        {
        }
    }
}
