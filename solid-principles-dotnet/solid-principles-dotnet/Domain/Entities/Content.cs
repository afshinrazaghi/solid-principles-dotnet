using solid_principles_dotnet.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solid_principles_dotnet.Domain.Entities
{
    public class Content: BaseEntity
    {
        public string? Title { get; set; }
        public string ContentText { get; set; }
    }
}
