using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Dynamics.WinePlans.Provider.Managers
{
    public partial class ClientConfiguration
    {
        public static ClientConfiguration Default { get { return ClientConfiguration.OneBox; } }

        public static ClientConfiguration OneBox = new ClientConfiguration()
        {
            UriString = "https://sitecoreserviceax7119b364e2504b8542aos.cloudax.dynamics.com/",
            UserName = "Kerry@sitecoreax7c.onmicrosoft.com",
            Password = "Sitec0re3",
            ActiveDirectoryResource = "https://sitecoreserviceax7119b364e2504b8542aos.cloudax.dynamics.com",
            ActiveDirectoryTenant = "https://login.windows.net/69dc6202-31d8-4d1f-a848-85c7118c335e",
            ActiveDirectoryClientAppId = "9f01cd56-76fe-4b6f-bb2c-feb78012f960",
        };

        public string UriString { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ActiveDirectoryResource { get; set; }
        public String ActiveDirectoryTenant { get; set; }
        public String ActiveDirectoryClientAppId { get; set; }
    }
}
