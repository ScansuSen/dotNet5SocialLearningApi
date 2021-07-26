using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SocialLearning.Entities
{
    public class Lesson
    { [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength (50)]
        public string LessonName { get; set; }
        public int? Education_Id { get; set; }
        [ForeignKey("Education_Id")]
        public virtual Education Education { get; set; }
      

      
    }
}
