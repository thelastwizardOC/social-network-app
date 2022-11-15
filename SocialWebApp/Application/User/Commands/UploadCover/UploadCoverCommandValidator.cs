using Application.User.Commands.UploadAvatar;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.Commands.UploadCover
{
    internal class UploadCoverCommandValidator : AbstractValidator<UploadCoverCommand>
    {
        public UploadCoverCommandValidator()
        {
            RuleFor(v => v.UserId).NotNull().WithMessage("User ID is required");
            RuleFor(v => v.Base64).NotEmpty().WithMessage("Image base64 string is required");
        }
    }
}
