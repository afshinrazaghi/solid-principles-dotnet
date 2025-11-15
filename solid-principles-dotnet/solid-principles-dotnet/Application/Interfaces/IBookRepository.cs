using solid_principles_dotnet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solid_principles_dotnet.Application.Interfaces
{
    public interface IBookRepository
    {
        Task<Book?> GetBookById(long id);
    }
}
