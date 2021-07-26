using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SocialLearning.Entities
{
   public class Question
    {
        [Key]
        public int ID { get; set; }
        public int? Lesson_Id { get; set; }
        [ForeignKey("Lesson_Id")]
        public virtual Lesson Lesson { get; set; }
        public int? User_Id { get; set; }
        [ForeignKey("User_Id")]
        public  virtual User User { get; set; }
        public int? Education_Id { get; set; }
        [ForeignKey("Education_Id")]
        public virtual Education Education { get; set; }
       
        public bool IsReplied { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        
    }

    
}
