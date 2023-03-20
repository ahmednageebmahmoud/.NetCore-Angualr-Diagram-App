using Microsoft.AspNetCore.Identity;


namespace Draw.Core.Model
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Diagram> Diagrams { get; set; }
    }
}
