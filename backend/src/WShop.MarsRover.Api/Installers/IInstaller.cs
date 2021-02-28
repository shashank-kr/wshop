using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace WShop.MarsRover.Api.Installers
{
    public interface IInstaller
    {
        void InstallServices(IServiceCollection serviceDescriptors, IConfiguration configuration);
    }
}
