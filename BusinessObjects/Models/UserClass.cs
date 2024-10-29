
namespace BusinessObjects.Models
{
    public partial class UserClass
    {
        public int UserClassId { get; set; }
        public int UserId { get; set; }
        public int ClassId { get; set; }

        public virtual Class Class { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
