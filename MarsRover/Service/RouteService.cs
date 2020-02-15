using MarsRover.Model;
using Microsoft.Extensions.Logging;

namespace MarsRover.Service
{
    public class RouteService : IRouteService
    {
        private readonly ILocationService _locationService;
        private readonly ILogger<RouteService> _logger;

        public RouteService(ILocationService locationService, ILogger<RouteService> logger)
        {
            _locationService = locationService;
            _logger = logger;
        }

        public void ApplyCommand(IRover rover)
        {
            foreach (var command in rover.RoverCommands)
            {

                switch (command)
                {
                    case 'L':
                        rover.TurnLeft();
                        break;
                    case 'R':
                        rover.TurnRight();
                        break;
                    case 'M':
                        rover.Move();
                        break;
                    default:
                        _logger.LogWarning($"Wrong Command: {command}, Valid Command set are: L, R, M");
                        break;
                }

            }
        }
    }
}