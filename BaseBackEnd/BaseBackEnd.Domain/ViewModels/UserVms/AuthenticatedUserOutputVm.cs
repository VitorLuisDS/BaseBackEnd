using System;

namespace BaseBackEnd.Domain.ViewModels.UserVms
{
    public class AuthenticatedUserOutputVm
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public int ProfileId { get; set; }
        public string ProfileName { get; set; }
        public string[] Roles { get; set; }
        public Guid Sid { get; set; }
        public bool StayConnected { get; set; } = false;
    }
}
