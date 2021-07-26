using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialLearning.Entities
{
    public class User
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(75)]
        public string UserName { get; set; }
        [StringLength(75)]
        public string FirstName { get; set; }
        [StringLength(75)]
        public string LastName { get; set; }
        [StringLength(75)]
        public string email { get; set; }
        [StringLength(75)]
        public string Password { get; set; }
        public int? Education_Id { get; set; }
        [ForeignKey("Education_Id")]

        public virtual Education Education { get; set; }


    }
}
