using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solid_principles_dotnet.Application.Features.Attahcmens.Commands
{
    public class CreateAttachmentCommand
    {
        public string BookName { get; set; }
        public string TableName { get; set; }
        public long PrimaryKeyId { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string ContentType { get; set; }
        public byte[] FileContent { get; set; }
        public long FileSize { get; set; }
    }
}
