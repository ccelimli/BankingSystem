using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Supports.Commands.Delete
{
    public class DeleteSupportValidator : AbstractValidator<DeleteSupportCommand>
    {
        public DeleteSupportValidator()
        {
            RuleFor(myClass => myClass.Id).NotEmpty().GreaterThan(0);
        }
    }
}
