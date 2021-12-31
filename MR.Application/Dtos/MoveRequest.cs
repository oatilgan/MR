namespace MR.Application.Dtos
{
    public class MoveRequest
    {
        public MoveRequest(List<int> maxCoordinates, List<StartCoordinatesMoves> startCoordinatesMoves)
        {
            MaxCoordinates = maxCoordinates;
            StartCoordinatesMoves = startCoordinatesMoves;


        }

        public List<int> MaxCoordinates { get; set; }

        public List<StartCoordinatesMoves> StartCoordinatesMoves { get; set; }


    }

    public class StartCoordinatesMoves
    {
        public string[] StartCoordinates { get; set; }

        public string Moves { get; set; }
    }
}