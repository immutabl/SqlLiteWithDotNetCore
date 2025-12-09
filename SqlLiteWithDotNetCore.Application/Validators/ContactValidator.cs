using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Validators;
using SqlLiteWithDotNetCore.Domain.Entities;

namespace SqlLiteWithDotNetCore.Application.Validators
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {

            RuleFor(x => x.Forename)
                .NotEmpty().WithMessage("Forename is required.")
                .MaximumLength(50).WithMessage("Forename cannot exceed 50 characters.");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Surname is required.")
                .MaximumLength(50).WithMessage("Surname cannot exceed 50 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .MaximumLength(50).WithMessage("Email cannot exceed 50 characters.")
                .EmailAddress(EmailValidationMode.Net4xRegex).WithMessage("Invalid email format.");

            RuleFor(x => x.Telno)
                .NotEmpty().WithMessage("Telephone number is required.")
                .MaximumLength(50).WithMessage("Telephone number cannot exceed 50 characters.");
        }
    }

}
