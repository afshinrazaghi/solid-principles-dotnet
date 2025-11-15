using solid_principles_dotnet.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solid_principles_dotnet.Domain.Entities
{
    public class Attachment:BaseEntity
    {
        public string TableName { get; set; }
        public long PrimaryKeyId { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string ContentType { get; set; }
        public byte[]? FileContent { get; set; }
        public string? FolderPath { get; set; }
        public long? FileSize { get; set; }
    }
}
