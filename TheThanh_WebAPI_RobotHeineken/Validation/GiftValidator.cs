﻿using FluentValidation;
using TheThanh_WebAPI_RobotHeineken.DTO;

namespace TheThanh_WebAPI_RobotHeineken.Validation
{
    public class GiftValidator : AbstractValidator<GiftDTO>
    {
        public GiftValidator()
        {
            RuleFor(m => m.GiftName)
               .NotEmpty().WithMessage("Giftname is required");
        }
    }
}
