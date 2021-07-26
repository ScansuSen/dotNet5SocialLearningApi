
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SocialLearning.Entities
{
   public class Answer
    {

        [Key]
        public int ID { get; set; }



        public int?  User_Id{ get; set; }
        [ForeignKey("User_Id")]
        public virtual User User { get; set; }
        public int? Education_Id { get; set; }
        [ForeignKey("Education_Id")]

        public virtual Education Education { get; set; }
        public int? Question_Id { get; set; }
        [ForeignKey("Question_Id")]

        public virtual Question Question { get; set; }
        public int? Lesson_Id { get; set; }
        [ForeignKey("Lesson_Id")]

        public virtual Lesson Lesson { get; set; }

        public bool IsCorrect { get; set; }
        public String Description { get; set; }
        public string ImgURL { get; set; }
    }
}