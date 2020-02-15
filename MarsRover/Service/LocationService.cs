using System;
using System.Linq;
using MarsRover.Model;
using Microsoft.Extensions.Logging;

namespace MarsRover.Service
{
    public class LocationService : ILocationService
    {
        private const int PARSED_X_POSITION_INDEX = 0;
        private const int PARSED_Y_POSITION_INDEX = 1;
        private const int PARSED_DIRECTION_INDEX = 2;
        private readonly ILogger<LocationService> _logger;

        public LocationService(ILogger<LocationService> logger)
        {
            _logger = logger;
        }

        public Model.Location Parse(string locationWithDirectionString)
        {
            var locationStringParts = locationWithDirectionString.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var location = new Model.Location();
            eDirection direction;

            location.XPosition = Int32.Parse(locationStringParts[PARSED_X_POSITION_INDEX]);
            location.YPosition = Int32.Parse(locationStringParts[PARSED_Y_POSITION_INDEX]);

            var directionChar = locationStringParts[PARSED_DIRECTION_INDEX]
                .ToUpper();

            if (!Enum.TryParse(directionChar, out direction))
                throw new SystemException("Invalid Direction. Sample Direction : W E S N");


            location.CurrentDirection = direction;

            _logger.LogInformation($"Created Location: {location}");

            return location;
        }
    }
}