
namespace WShop.MarsRover.Api.Constants.Routes.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";        
        public const string Version = "v1";

        public const string Base = Root + "/" + Version + "/[controller]";
        
        public static class PlateauSurface
        {           
            public const string CreatePlateauSurface = Base + "/CreatePlateauSurface";
            public const string DeployRover = Base + "/DeployRover";
            public const string MoveRover = Base + "/MoveRover";

        }


    }


}