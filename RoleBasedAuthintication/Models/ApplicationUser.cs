using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RoleBasedAuthintication.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    [Table("UserAccounts")]
    public class ApplicationUser : IdentityUser
    {
        public UserProfile UserProfile { get; set; }
    }

    public class UserProfile
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string GitHubUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string GooglePlusUrl { get; set; }
        public string OtherUrl { get; set; }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ApplicationUserID { get; set; }
        

        public ApplicationUser ApplicationUser { get; set; }
    }
    
}
