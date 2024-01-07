using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Supports.Commands.Update
{
    public class UpdateSupportValidator : AbstractValidator<UpdateSupportCommand>
    {
        public UpdateSupportValidator()
        {
            RuleFor(post => post.Id).GreaterThan(0);
            RuleFor(post => post.Title).NotEmpty().MaximumLength(500);
            RuleFor(post => post.Content).NotEmpty();
            RuleFor(post => post.UserId).GreaterThan(0);
        }
    }
}
