// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace IsubuSatis.IdentityServer
{
    public static class Config
    {

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("resource_katalog"){ Scopes = {"kategori", "kategori_list"}},
                new ApiResource("resource_fotografDepo"){ Scopes = {"fotograf"}},
                new ApiResource("resource_sepet"){ Scopes = {"sepet"}},
                new ApiResource("resource_indirim"){ Scopes = {"indirim"}},
                new ApiResource("resource_siparis"){ Scopes = {"siparis"}},
                new ApiResource("resource_odeme"){ Scopes = {"odeme"}},
                new ApiResource("resource_gateway"){ Scopes = {"gateway"}},
                new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource(){ Name = "offline_access" },
                
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("kategori"),
                new ApiScope("kategori_list"),
                new ApiScope("kategori_create"),
                new ApiScope("kategori_update"),
                new ApiScope("kategori_delete"),
                new ApiScope("fotograf"),
                new ApiScope("sepet"),
                new ApiScope("indirim"),
                new ApiScope("siparis"),
                new ApiScope("odeme"),
                new ApiScope("gateway"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName),

            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientName ="ISUBU Satış Uygulaması",
                    ClientId="IsubuSatisMvc",
                    
                    ClientSecrets = { new Secret("IsubuSecret".Sha256())},
                    AllowedScopes= { "kategori", IdentityServerConstants.LocalApi.ScopeName, "fotograf" },
                    AllowedGrantTypes = GrantTypes.ClientCredentials

                },
                new Client
                {
                    ClientName ="ISUBU Satış Uygulaması",
                    ClientId="IsubuSatisMvcForuser",

                    ClientSecrets = { new Secret("IsubuSecretForUser".Sha256())},
                    AllowedScopes= { "kategori", "sepet",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        IdentityServerConstants.LocalApi.ScopeName ,

                    },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowOfflineAccess = true,
                    AccessTokenLifetime = (int)TimeSpan.FromHours(3).TotalSeconds,
                    RefreshTokenExpiration = TokenExpiration.Absolute,
                    AbsoluteRefreshTokenLifetime = (int)TimeSpan.FromDays(15).TotalSeconds,
                    RefreshTokenUsage = TokenUsage.ReUse,
                }
                //// m2m client credentials flow client
                //new Client
                //{
                //    ClientId = "m2m.client",
                //    ClientName = "Client Credentials Client",

                //    AllowedGrantTypes = GrantTypes.ClientCredentials,
                //    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                //    AllowedScopes = { "scope1" }
                //},

                //// interactive client using code flow + pkce
                //new Client
                //{
                //    ClientId = "interactive",
                //    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                //    AllowedGrantTypes = GrantTypes.Code,

                //    RedirectUris = { "https://localhost:44300/signin-oidc" },
                //    FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                //    PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                //    AllowOfflineAccess = true,
                //    AllowedScopes = { "openid", "profile", "scope2" }
                //},
            };
    }
}