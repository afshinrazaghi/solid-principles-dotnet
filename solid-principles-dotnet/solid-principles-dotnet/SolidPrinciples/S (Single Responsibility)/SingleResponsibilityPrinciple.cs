using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using AutoMapper;
using FluentValidation.Results;
using MediatR;
using solid_principles_dotnet.Application.Features.Attahcmens.Commands;
using solid_principles_dotnet.Application.Features.Contents.Commands;
using solid_principles_dotnet.Application.Features.Contents.Commands.Validators;
using solid_principles_dotnet.Application.Interfaces;
using solid_principles_dotnet.Application.Models;
using solid_principles_dotnet.Application.Services;
using solid_principles_dotnet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace solid_principles_dotnet.SolidPrinciples
{
    public class SingleResponsibilityPrinciple
    {
        #region Example 1
        #region Bad Example
        public class CreateContentCommandHandlerBadSolution : IRequestHandler<CreateContentCommand, Result>
        {
            private readonly IContentRepository _contentRepository;
            private readonly IBookRepository _bookRepository;
            private readonly IAttachmentRepository _attachmentRepository;
            private readonly IMapper _mapper;
            private readonly IValidator _validator;
            public CreateContentCommandHandlerBadSolution(IContentRepository contentRepository, IBookRepository bookRepository, IAttachmentRepository attachmentRepository, IMapper mapper, IValidator validator)
            {
                _contentRepository = contentRepository;
                _bookRepository = bookRepository;
                _attachmentRepository = attachmentRepository;
                _mapper = mapper;
                _validator = validator;
            }

            public async Task<Result> Handle(CreateContentCommand request, CancellationToken cancellationToken)
            {
                var validationResult = await _validator.ValidateAsync<CreateContentCommandValidator, CreateContentCommand>(request);
                if (!validationResult.IsValid)
                    return Result.Invalid(validationResult.AsErrors());

                var book = await _bookRepository.GetBookById(request.BookId);
                if (book == null)
                    return Result.Error("The Book not found!");

                var clientContent = _mapper.Map<Content>(request);
                var createdContent = await _contentRepository.CreateContent(clientContent);

                if (request.FormFiles != null)
                {
                    var attachments = request.FormFiles.Select(formFile =>
                    {
                        MemoryStream ms = new MemoryStream();
                        formFile.CopyTo(ms);
                        return new Attachment()
                        {
                            ContentType = "image/jpeg",
                            Extension = Path.GetExtension(formFile.FileName),
                            Name = formFile.FileName,
                            TableName = "Content",
                            PrimaryKeyId = createdContent.Id,
                            FileContent = ms.ToArray(),
                            FileSize = ms.Length
                        };
                    });

                    foreach (var attachment in attachments)
                    {
                        await _attachmentRepository.CreateAttachment(attachment);
                    }
                }

                return Result.Success();

            }

        }
        #endregion
        #region Good Exmple
        public class CreateContentCommandHandlerGoodSolution : IRequestHandler<CreateContentCommand, Result>
        {
            private readonly IContentRepository _contentRepository;
            private readonly IBookRepository _bookRepository;
            private readonly IAttachmentRepository _attachmentRepository;
            private readonly IMapper _mapper;
            private readonly IValidator _validator;
            private readonly IAttachmentService _attachmentService;
            public CreateContentCommandHandlerGoodSolution(IContentRepository contentRepository, IBookRepository bookRepository, IAttachmentRepository attachmentRepository, IMapper mapper, IValidator validator, IAttachmentService attachmentService)
            {
                _contentRepository = contentRepository;
                _bookRepository = bookRepository;
                _attachmentRepository = attachmentRepository;
                _mapper = mapper;
                _validator = validator;
                _attachmentService = attachmentService;
            }

            public async Task<Result> Handle(CreateContentCommand request, CancellationToken cancellationToken)
            {
                var validationResult = await _validator.ValidateAsync<CreateContentCommandValidator, CreateContentCommand>(request);
                if (!validationResult.IsValid)
                    return Result.Invalid(validationResult.AsErrors());

                var book = await _bookRepository.GetBookById(request.BookId);
                if (book == null)
                    return Result.Error("The Book not found!");

                var clientContent = _mapper.Map<Content>(request);
                var createdContent = await _contentRepository.CreateContent(clientContent);

                if (request.FormFiles != null)
                {
                    await _attachmentService.CreateAttachmentForContentAsync(request.FormFiles, createdContent);
                }

                return Result.Success();

            }

        }
        #endregion
        #endregion
    }
}
