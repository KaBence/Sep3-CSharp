﻿using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Auth;

public static class AuthorizationPolicies
{
    public static void AddPolicies(IServiceCollection services)
    {
        services.AddAuthorizationCore(options =>
        {
            options.AddPolicy("Farmer", a =>
                a.RequireAuthenticatedUser().RequireClaim("Actor", "Farmer"));
    
            options.AddPolicy("Customer", a =>
                a.RequireAuthenticatedUser().RequireClaim("Actor", "Customer"));
            
            options.AddPolicy("SecurityLevel2OrAbove", a =>
                a.RequireAuthenticatedUser().RequireAssertion(context =>
                {
                    Claim? levelClaim = context.User.FindFirst(claim => claim.Type.Equals("SecurityLevel"));
                    if (levelClaim == null) return false;
                    return int.Parse(levelClaim.Value) >= 2;
                }));
        });
    }
}