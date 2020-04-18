namespace Catstagram.Server.Data.Models
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public IEnumerable<Cat> Cats { get; } = new HashSet<Cat>();
    }
}
