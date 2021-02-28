using WShop.MarsRover.Application.Common.Configurations;

namespace WShop.MarsRover.Infrastructure.Configurations
{
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        public string ApiKeyHeaderName { get; set; }
        public string ApiKeyValue { get; set; }             
    }
}

