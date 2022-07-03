using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class UserRoleAssignDto
    {
        public UserRoleAssignDto()
        {
            RoleAssignDtos = new List<RoleAssignDto>();
            //'IList' bir interface oldugu için initialize olmayacak. Bu sebeple Constructor içinde bunu oluşturduk.
        }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public IList<RoleAssignDto> RoleAssignDtos { get; set; }
    }
}
