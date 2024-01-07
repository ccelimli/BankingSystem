using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Supports.Commands.Create
{
    public class CreateSupportValidatorctor :AbstractValidator<CreateSupportCommand>
    {
        public CreateSupportValidatorctor()
        {
            RuleFor(post => post.Title).NotEmpty().MaximumLength(500); 
            RuleFor(post => post.Content).NotEmpty();
            RuleFor(post => post.UserId).GreaterThan(0);

        }
    }
}
