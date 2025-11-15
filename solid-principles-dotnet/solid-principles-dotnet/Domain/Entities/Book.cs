using solid_principles_dotnet.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solid_principles_dotnet.Domain.Entities
{
    public class Book:BaseEntity
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string? Description { get; set; }
    }
}
