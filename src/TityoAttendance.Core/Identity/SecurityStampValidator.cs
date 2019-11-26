﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using TityoAttendance.Authorization.Roles;
using TityoAttendance.Authorization.Users;
using TityoAttendance.MultiTenancy;

namespace TityoAttendance.Identity
{
    public class SecurityStampValidator : AbpSecurityStampValidator<Tenant, Role, User>
    {
        public SecurityStampValidator(
            IOptions<SecurityStampValidatorOptions> options, 
            SignInManager signInManager,
            ISystemClock systemClock) 
            : base(
                  options, 
                  signInManager, 
                  systemClock)
        {
        }
    }
}
