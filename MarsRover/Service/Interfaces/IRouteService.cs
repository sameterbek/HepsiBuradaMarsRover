using System;
using MarsRover.Model;

namespace MarsRover.Service
{
    public interface IRouteService
    {
        void ApplyCommand(IRover rover);
    }
}