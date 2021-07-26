using FluentValidation;
using SocialLearning.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialLearning.Business.ValidationRules
{
   public class EducationValidator : AbstractValidator<Education>
    {

        public EducationValidator()
        {
            RuleFor(x => x.ID).NotNull();
            RuleFor(x => x.StatusName).NotEmpty();

        }

    }
}
