namespace MarsRover.Service
{
    public interface ILocationService
    {

        Model.Location Parse(string locationWithDirectionString);
    }
}