﻿using System;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using TCMManagement.BusinessLayer;
using TCMManagement.Models;

[assembly: OwinStartup(typeof(TCMManagement.Startup))]

namespace TCMManagement
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            var myProvider = new TcmAuthorizationServerProvider();
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(10),
                Provider = myProvider
            };


            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            HttpConfiguration config = new HttpConfiguration();

            var mapperConfig = new AutoMapper.MapperConfiguration(c =>
            {
                c.AddProfile(new ApplicationProfile());
            });
            var mapper = mapperConfig.CreateMapper();
            config.Services.Add(typeof(IMapper), mapper);

            WebApiConfig.Register(config);
        }
    }
}
