﻿using AuthenticationService.Application.Commands;
using AuthenticationService.Application.Validation.Abstractions.Interfaces;
using FluentValidation;

namespace AuthenticationService.Application.Validation
{
    public class ChangeUserPasswordValidator : AbstractValidator<ChangeUserPasswordCommand>
    {
        private readonly IValidationConditions _validateConditions;

        public ChangeUserPasswordValidator(IValidationConditions validateConditions)
        {
            _validateConditions = validateConditions;
            CreateRules();
        }

        private void CreateRules()
        {
            RuleFor(cmd => cmd.Entity)
                .NotNull()
                .WithMessage(cmd => "Entity is invalid");

            RuleFor(cmd => cmd.Entity.UserName)
                .Must(_validateConditions.IsNotNullOrWhitespace)
                .WithMessage(cmd => "Username is required field");

            RuleFor(cmd => cmd.Entity.OldPassword)
                .Must(_validateConditions.IsValidPassword)
                .WithMessage(cmd => "Old password must contain upper letter and digit");

            RuleFor(cmd => cmd.Entity.NewPassword)
                .Must(_validateConditions.IsValidPassword)
                .WithMessage(cmd => "New password must contain upper letter and digit");

            RuleFor(cmd => cmd.Entity)
                .Must(_validateConditions.IsValidAuthenticate)
                .WithMessage(cmd => "Wrong username or password");
        }
    }
}
