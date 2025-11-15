using solid_principles_dotnet.Application.Models;
using solid_principles_dotnet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solid_principles_dotnet.Application.Services
{
    public interface IAttachmentService
    {
        Task CreateAttachmentForContentAsync(List<IFormFile> files, Content content);
    }
}
