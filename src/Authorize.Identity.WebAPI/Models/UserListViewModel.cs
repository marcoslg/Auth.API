using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Authorize.Identity.WebAPI.Models
{
    public class UserListViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        [Display(Name = "Picture")]
        public string Picture
        {
            get;
            set;
        }

        [Display(Name = "UserName")]
        public string UserName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        internal void UpdateMetadata(IEnumerable<Claim> claim)
        {
            Picture = claim.ValueOf("picture");
            Name = claim.ValueOf("given_name");
        }
    }
}
