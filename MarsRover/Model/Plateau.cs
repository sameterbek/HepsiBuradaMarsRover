namespace MarsRover.Model
{
    public class Plateau
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }

        public override string ToString() => $"XPos: {XPosition}, YPos:{YPosition}";
    }
}