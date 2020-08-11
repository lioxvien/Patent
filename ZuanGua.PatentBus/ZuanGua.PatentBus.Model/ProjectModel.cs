using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuanGua.PatentBus.Model
{
    public class ProjectModel
    {

    }

    public class UserBaseInfo
    {
        public string USERID { get; set; }
        public string MOBILE { get; set; }
        public int? UserRole { get; set; }
        public string InviteCode { get; set; }
        public string MyInviteCode { get; set; }
        public int? Point { get; set; }
    }

    public class RegisterModel
    {
        public string USERNAME { get; set; }
        public string MOBILE { get; set; }
        public string PASSWORD { get; set; }
        public string InviteCode { get; set; }
        public string YZM { get; set; }
    }
}
