using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Commands.UpdateLanguage
{
    public class UpdateLanguageCommandValidator : AbstractValidator<UpdateLanguageCommand>
    {

        public UpdateLanguageCommandValidator()
        {
            RuleFor(u => u.Name).NotEmpty();
            RuleFor(u => u.Name).NotNull();
            RuleFor(u => u.Name).MinimumLength(1);
        }

    }
}
