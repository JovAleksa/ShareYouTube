using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareYouTube.Models.ApplicationUserViewModels
{
    public class UserRolesViewModel
    {
        public string Id { get; set; }
        public string RoleName { get; set; }
        public Boolean HasRole { get; set; }
    }
}
