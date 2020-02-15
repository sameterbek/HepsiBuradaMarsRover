using System;
using Microsoft.Extensions.Logging;
using MarsRover.Model;

namespace MarsRover.Service
{
    public class PlateauService : IPlateauService
    {
        private readonly ILogger<PlateauService> _logger;

        public PlateauService(ILogger<PlateauService> logger)
        {
            _logger = logger;
        }

        public bool IsLocationInBounds(Plateau plateau, Location location)
        {
            return location.XPosition >= 0 &&
                   location.XPosition <= plateau.XPosition &&
                   location.YPosition >= 0 &&
                   location.YPosition <= plateau.YPosition;
        }

        public Plateau Parse(string plateauBoundString)
        {
            var plateau = new Plateau();
            
            var bounds = plateauBoundString.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            plateau.XPosition = Int32.Parse(bounds[0]);
            plateau.YPosition = Int32.Parse(bounds[1]);

            _logger.LogInformation($"Plateau Created, Coordinates: {plateau}");
            
            return plateau;
        }
    }
}