 using SocialLearning.Business.Abstract;
using SocialLearning.DataAccess.Concrete;
using SocialLearning.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialLearning.Business.Concrete
{


    public class EducationManager : IEducationService
    {
        private EducationRepo _educationRepo;
            public EducationManager()
        {
            _educationRepo = new EducationRepo();
        }

        public async Task< Education> CreateEducation(Education education)
        {
            return await _educationRepo.CreateEducation(education);
        }

        public async Task DeleteEducation(int id)
        {
            await _educationRepo.DeleteEducation(id);
        }

        public async Task<List<Education>> GetAllEducations()
        {
            return await _educationRepo.GetAllEducations();
        }

        public async Task<Education> GetEducationById(int id)
        {
            return await _educationRepo.GetEducationById(id);
        }

        public async Task<Education> UpdateEducation(Education education)
        {
            return await _educationRepo.UpdateEducation(education)
  ;        }
    }
}
