using FluentValidation;
using solid_principles_dotnet.Application.Features.Contents.Commands;
using solid_principles_dotnet.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solid_principles_dotnet.Application.Features.Contents.Commands.Validators
{
    public class CreateContentCommandValidator : AbstractValidator<CreateContentCommand>
    {
        public CreateContentCommandValidator()
        {
            // write validations
            RuleFor(book => book.Title)
                .NotEmpty().WithMessage("Book Title is mandatory!");
        }
    }
}
