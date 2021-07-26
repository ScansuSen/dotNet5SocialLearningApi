using FluentValidation;
using SocialLearning.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialLearning.Business.ValidationRules
{
   public class AnswerValidator : AbstractValidator<Answer>
    {
        public AnswerValidator()
        {
            RuleFor(x => x.Education_Id).NotEmpty();
            RuleFor(x => x.Lesson_Id).NotEmpty();
            RuleFor(x => x.Question_Id).NotEmpty();
        }
    }
}