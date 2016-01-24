﻿using System.Threading.Tasks;

namespace BaoVietCore.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResult> WindowsHelloAuthen();

        AuthenticationResult PasswordAuthen(string input);

        void CreatePassword(string password);
    }

    public enum AuthenticationResult
    {
        NotAvailable,
        Success,
        Fail
    }
}