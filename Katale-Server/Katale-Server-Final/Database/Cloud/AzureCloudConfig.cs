using Microsoft.Azure.KeyVault;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Katale_Server_Final.Database.Cloud
{
    public class AzureCloudConfig : IConfig
    {
        private string CloudConnectionString = null;

        public AzureCloudConfig()
        {
            LoadConfigurations();
        }

        public string GetConnectionString()
        {
            return CloudConnectionString;
        }

        public void LoadConfigurations()
        {
            LoadCloudConnections().Wait();
        }

        private async Task LoadCloudConnections()
        {
            var keyVaultClient = new KeyVaultClient(AuthenticateVaultAsync);

            var result = await keyVaultClient.GetSecretAsync("https://kataaledbvault.vault.azure.net/secrets/kataledatabaseazure/1c829cfd490c42058ef43b6ee9765643");

            CloudConnectionString = result.Value;

        }

        private static async Task<string> AuthenticateVaultAsync(string authority, string resource, string scope)
        {

            string ClientID = "67168946-d6c7-4b2b-a785-638bcac8e0e7";
            string Secret = "X-U.qr]F4{})9Ss:6EmCfO]Z$GSB>uPAf0RY+F";
            var clientCredential = new ClientCredential(ClientID, Secret);
            AuthenticationContext authenticationContext = new AuthenticationContext(authority);
            var result = await authenticationContext.AcquireTokenAsync(resource, clientCredential);
            return result.AccessToken;

        }
    }
}