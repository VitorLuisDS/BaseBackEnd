using System;

namespace BaseBackEnd.Domain.ViewModel.UserVms
{
    public class AuthenticatedUserOutputVm
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string[] ProfilesNames { get; set; }
        public Guid Sid { get; set; }
        public bool StayConnected { get; set; } = false;
    }
}
