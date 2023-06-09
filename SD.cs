using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace identity;

public static class SD
{
    public const string Admin = "Admin";
    public const string Customer = "Customer";
    public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource> {
        new IdentityResources.OpenId(),
        new IdentityResources.Email(),
        new IdentityResources.Profile()
    };
    public static IEnumerable<ApiScope> ApiScopes => 
        new List<ApiScope> { 
            new ApiScope("mango","mango Server"),
            new ApiScope(name:"read", displayName:"Read your data."),
            new ApiScope(name:"write", displayName:"write your data."),
            new ApiScope(name:"delete", displayName:"delete your data.")
    };
    public static IEnumerable<Client> Clients => 
        new List<Client> {
            new Client {
                ClientId = "client",
                ClientSecrets = { new Secret("scret".Sha256())},
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = {"read","write","profile"}
            },
            new Client {
                ClientId = "mango",
                ClientSecrets = { new Secret("scret".Sha256())},
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = {"http://localhost:5187/signin-oidc"},
                PostLogoutRedirectUris = {"http://localhost:5187/signout-callback-oidc"},
                AllowedScopes = new List<string> {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "mango"
                }
            },
        };
}
