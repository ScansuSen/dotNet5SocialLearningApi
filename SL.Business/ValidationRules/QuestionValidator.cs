using FluentValidation;
using SocialLearning.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialLearning.Business.ValidationRules
{
   public class QuestionValidator: AbstractValidator<Question>
    {
        Question question = new Question();
        public QuestionValidator()
        {
            RuleFor(x => x.ID).NotEmpty();
            RuleFor(x => x.Education_Id).NotEmpty();
            RuleFor(x => x.Lesson_Id).NotEmpty();
            if (question.Description==null)
            {
                RuleFor(x => x.ImageUrl).NotEmpty();
            }
            if (question.ImageUrl == null)
            {
                RuleFor(x => x.Description).NotEmpty();
            }

        }
    }
}
