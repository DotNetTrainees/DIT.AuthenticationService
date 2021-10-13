﻿using System.Collections.Generic;

namespace AuthenticationService.Contracts.Incoming
{
    public class RegistrationUserDto
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ICollection<string> Roles { get; set; }
    }
}
