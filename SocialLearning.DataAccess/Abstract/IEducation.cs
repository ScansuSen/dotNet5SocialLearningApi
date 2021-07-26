using SocialLearning.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialLearning.DataAccess.Abstract
{
   public interface IEducation
    {

       Task< List<Education>> GetAllEducations();

        Task<Education> CreateEducation(Education education);
        Task<Education> GetEducationById(int id);
        Task<Education> UpdateEducation(Education education);
        Task DeleteEducation(int id);
        

    }
}
