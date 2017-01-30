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
            var aadTenant = ClientConfiguration.Default.ActiveDirectoryTenant;
            var clientAppId = ClientConfiguration.Default.ActiveDirectoryClientAppId;
            var clientKey = ClientConfiguration.Default.ActiveDirectoryClientAppId;
            var aadResource = ClientConfiguration.Default.ActiveDirectoryResource;

            var authenticationContext = new AuthenticationContext(aadTenant);
            var clientCredential = new ClientCredential(clientAppId, clientKey);
            var upc = new UserPasswordCredential(ClientConfiguration.Default.UserName, ClientConfiguration.Default.Password);

            var authenticationResult = authenticationContext.AcquireTokenAsync(
                aadResource,
                clientAppId,
                new Uri("http://odata"),
                new PlatformParameters(PromptBehavior.Always)).Result;

            return authenticationResult.CreateAuthorizationHeader();
        }
    }
}
