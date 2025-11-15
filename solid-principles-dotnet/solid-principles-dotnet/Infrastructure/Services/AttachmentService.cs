using MediatR;
using solid_principles_dotnet.Application.Interfaces;
using solid_principles_dotnet.Application.Models;
using solid_principles_dotnet.Application.Services;
using solid_principles_dotnet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solid_principles_dotnet.Infrastructure.Services
{
    public class AttachmentService : IAttachmentService
    {
        private IAttachmentRepository _attachmentRepository;

        public AttachmentService(IAttachmentRepository attachmentRepository)
        {
            _attachmentRepository = attachmentRepository;
        }

        public async Task CreateAttachmentForContentAsync(List<IFormFile> files, Content content)
        {
            var attachments = files.Select(formFile =>
            {
                MemoryStream ms = new MemoryStream();
                formFile.CopyTo(ms);
                return new Attachment()
                {
                    ContentType = "image/jpeg",
                    Extension = Path.GetExtension(formFile.FileName),
                    Name = formFile.FileName,
                    TableName = "Content",
                    PrimaryKeyId = content.Id,
                    FileContent = ms.ToArray(),
                    FileSize = ms.Length
                };
            });

            foreach (var attachment in attachments)
            {
                await _attachmentRepository.CreateAttachment(attachment);
            }
        }
    }
}
