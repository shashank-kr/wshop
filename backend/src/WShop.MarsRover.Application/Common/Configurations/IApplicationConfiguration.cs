namespace WShop.MarsRover.Application.Common.Configurations
{
    public interface IApplicationConfiguration
    {
        string ApiKeyHeaderName { get; }
        string ApiKeyValue { get; }        
    }
}

