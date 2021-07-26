using SocialLearning.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialLearning.Business.Abstract
{
   public interface IEducationService
    {
        Task<List<Education>> GetAllEducations();
     Task< Education> GetEducationById(int id);
        Task<Education> CreateEducation(Education education);
        Task<Education> UpdateEducation(Education education);
        Task DeleteEducation(int id);
    }
}
