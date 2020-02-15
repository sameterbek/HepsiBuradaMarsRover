using MarsRover.Model;

namespace MarsRover.Service
{
    public interface IPlateauService
    {
        bool IsLocationInBounds(Plateau plateau, Location location);

        Plateau Parse(string plateauBoundString);
    }
}