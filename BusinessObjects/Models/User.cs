
namespace BusinessObjects.Models
{
    public partial class User
    {
        public User()
        {
            UserClasses = new HashSet<UserClass>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int RoleId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Password { get; set; } = null!;

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<UserClass> UserClasses { get; set; }
    }
}
