using FluentValidation;
using SocialLearning.Business.Abstract;
using SocialLearning.DataAccess;
using SocialLearning.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialLearning.Business.ValidationRules
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator(){
            RuleFor(x => x.ID).NotNull();
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();

            RuleFor(x => x.email)
     .NotEmpty()
     .WithMessage("gerekli")
     .EmailAddress();
     
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).MinimumLength(6);
            RuleFor(x => x.Education_Id).NotEmpty();


        }
    }
}
