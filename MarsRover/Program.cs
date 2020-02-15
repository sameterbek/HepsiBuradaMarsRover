using System;
using System.Collections.Generic;
using MarsRover.Model;
using MarsRover.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = SetupDependencyContainer();
            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();
            var routeService = serviceProvider.GetService<IRouteService>();
            var plateauService = serviceProvider.GetService<IPlateauService>();
            var locationService = serviceProvider.GetService<ILocationService>();

            string consoleHeader = @"
                                     ****************************
                                     *       HEPSİBURADA        *
                                     *       MARS ROVER         *
                                     ****************************";
            Console.WriteLine(consoleHeader);
            Console.WriteLine("Mars Rover Challenge");
            Console.WriteLine("Sample Template: ");
            Console.WriteLine("Plateau Bounds: 5 5");
            Console.WriteLine("Rover Position and Direction: 1 3 W");
            Console.WriteLine("Move Commands: LMLMLMLMM");
            Console.WriteLine($"{Environment.NewLine}");

            Console.WriteLine("Please Enter Plateau Bounds :");
            var plateauString = Console.ReadLine();
            var plateau = plateauService.Parse(plateauString);
            List<Rover> rovers = new List<Rover>();
            bool addRover = true;
            while (addRover)
            {
                Console.WriteLine("Please Enter Rover Location. Sample Rover Location 5 5 W");
                var roverLocationString = Console.ReadLine();
                var roverLocation = locationService.Parse(roverLocationString);

                Console.WriteLine("Please Enter Move Command Set :");
                var commandString = Console.ReadLine();

                rovers.Add(new Rover(roverLocation, commandString));

                Console.WriteLine("Enter 1 to Add Another Rover");
                addRover = Console.ReadLine() == "1";
            };

            foreach (var rover in rovers)
            {
                routeService.ApplyCommand(rover);

                var isLocationInBounds = plateauService.IsLocationInBounds(plateau, rover.RoverLocation);
                if (!isLocationInBounds)
                    logger.LogWarning($" {rovers.IndexOf(rover) + 1}. rover can not move with this move set, current location is out of plateau bounds: currentLocation: {rover.RoverLocation}, plateauLocation: {plateau}");
                else
                    logger.LogInformation($"{rovers.IndexOf(rover) + 1}. rover move success. Rover currentLocation: {rover.RoverLocation}");
            }

            Console.ReadLine();
        }

        static ServiceProvider SetupDependencyContainer()
        {
            //setup our DI
            return new ServiceCollection()
                .AddLogging(loggerFactory =>
                {
                    loggerFactory.ClearProviders().AddConsole()
                        .AddFilter(logLevel => logLevel >= LogLevel.Debug);
                })
                .AddSingleton<IRouteService, RouteService>()
                .AddSingleton<IPlateauService, PlateauService>()
                .AddSingleton<ILocationService, LocationService>()
                .BuildServiceProvider();
        }
    }
}