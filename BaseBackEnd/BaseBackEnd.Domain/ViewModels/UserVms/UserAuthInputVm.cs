﻿namespace BaseBackEnd.Domain.ViewModels.UserVms
{
    public class UserAuthInputVm
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool StayConnected { get; set; } = false;
    }
}
