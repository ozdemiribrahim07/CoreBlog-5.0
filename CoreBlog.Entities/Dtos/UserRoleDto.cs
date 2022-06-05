using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Entities.Dtos
{
    public class UserRoleDto
    {
        public UserRoleDto()
        {
            RoleDto = new List<RoleDto>();
        }

        public int Userid { get; set; }
        public string Username { get; set; }
        public IList<RoleDto> RoleDto { get; set; }

    }
}
