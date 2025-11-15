using FluentValidation;
using FluentValidation.Results;
using solid_principles_dotnet.Application.Features.Contents.Commands;
using solid_principles_dotnet.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solid_principles_dotnet.Application.Interfaces
{
    public interface IValidator
    {
        Task<ValidationResult> ValidateAsync<TValidator, TModel>(TModel item)
           where TValidator : AbstractValidator<TModel>, new();

    }
}
