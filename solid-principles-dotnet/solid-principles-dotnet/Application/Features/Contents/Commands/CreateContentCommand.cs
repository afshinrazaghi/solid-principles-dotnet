using Ardalis.Result;
using MediatR;
using solid_principles_dotnet.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solid_principles_dotnet.Application.Features.Contents.Commands
{
    public class CreateContentCommand : IRequest<Result>
    {
        public long BookId { get; set; }
        public string? Title { get; set; }
        public string ContentText { get; set; }
        public List<IFormFile>? FormFiles { get; set; }
    }
}
