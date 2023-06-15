using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryManagement.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        ICountryRepository Country { get; }
        int Save();
    }
}
