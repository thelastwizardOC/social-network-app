using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.UploadAvatar
{
    public class UploadAvatarCommandValidator : AbstractValidator<UploadAvatarCommand>
    {
        public UploadAvatarCommandValidator()
        {
            RuleFor(v => v.UserId).NotNull().WithMessage("User ID is required");
            RuleFor(v => v.Base64).NotEmpty().WithMessage("Image base64 string is required");
        }
    }
}
