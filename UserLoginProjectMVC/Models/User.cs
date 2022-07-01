using System.ComponentModel.DataAnnotations;

namespace UserLoginProjectMVC.Models
{
    public class User
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}
