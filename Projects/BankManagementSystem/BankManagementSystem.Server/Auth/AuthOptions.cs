﻿using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BankManagementSystem.Auth;

internal class AuthOptions
{
    public const string ISSUER = "BankServer";
    public const string AUDIENCE = "MyAuthClient"; // потребитель токена
    const string KEY = "2EC1EE51-1100-4347-BF22-EEB6CB8B0695";   // ключ для шифрации
    public const int LIFETIME = 30; // время жизни токена - 15 минута
    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}
