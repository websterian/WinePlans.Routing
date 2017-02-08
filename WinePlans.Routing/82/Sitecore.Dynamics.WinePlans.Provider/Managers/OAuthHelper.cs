using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Sitecore.Dynamics.WinePlans.Provider.Managers
{
    public class OAuthHelper
    {
        /// <summary>
        /// The header to use for OAuth.
        /// </summary>
        public const string OAuthHeader = "Authorization";

        /// <summary>
        /// Retrieves an authentication header from the service.
        /// </summary>
        /// <returns>The authentication header for the Web API call.</returns>
        public static string GetAuthenticationHeader()
        {
            var authenticationContext = new AuthenticationContext(ClientConfiguration.Default.ActiveDirectoryTenant);
            var passwordCred = new UserPasswordCredential(ClientConfiguration.Default.UserName, ClientConfiguration.Default.Password);

            var authenticationResult =
                authenticationContext.AcquireTokenAsync(
                    ClientConfiguration.Default.ActiveDirectoryResource,
                    ClientConfiguration.Default.ActiveDirectoryClientAppId,
                    passwordCred).Result;

            return authenticationResult.CreateAuthorizationHeader();
        }
    }
}
