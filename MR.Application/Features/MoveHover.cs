using MR.Application.Contracts;
using MR.Application.Dtos;
using MR.Domain.Entities;
using MR.Domain.Enums;

namespace MR.Application.Features
{
    public class MoveHover : IMoveHover
    {
        public List<MoveResponse> Move(List<MoveRequest> moveRequests)
        {
            var result = new List<MoveResponse>();

            foreach (var moveRequest in moveRequests)
            {

                foreach (var startCoordinatesMove in moveRequest.StartCoordinatesMoves)
                {
                    var hover = new Hover();
                    var moveResponse = new MoveResponse();
                    if (startCoordinatesMove.StartCoordinates.Count() == 3)
                    {
                        hover.X = Convert.ToInt32(startCoordinatesMove.StartCoordinates[0]);
                        hover.Y = Convert.ToInt32(startCoordinatesMove.StartCoordinates[1]);
                        hover.Direction = (Ways)Enum.Parse(typeof(Ways), startCoordinatesMove.StartCoordinates[2]);
                    }
                    else
                    {
                        moveResponse.ErrorMessages.Add("Start Coordinates are wrong");
                    }
                    foreach (var move in startCoordinatesMove.Moves)
                    {
                        switch (move)
                        {
                            case 'R':
                                SpinNinetyToRightDegrees(hover);
                                break;
                            case 'L':
                                SpinNinetyToLeftDegrees(hover);
                                break;
                            case 'M':
                                MoveForward(hover);
                                break;
                            default:
                                moveResponse.ErrorMessages.Add(" Invalid way");
                                break;

                        }

                        if (hover.X < 0 || hover.X > moveRequest.MaxCoordinates[0] || hover.Y < 0 ||
                            hover.Y > moveRequest.MaxCoordinates[1])
                        {
                            moveResponse.ErrorMessages.Add($" Exceeded given coordinates {moveRequest.MaxCoordinates[0]}, {moveRequest.MaxCoordinates[1]}");
                        }

                    }

                    moveResponse.FinalCoordinates = $"{hover.X} {hover.Y} {hover.Direction}";
                    moveResponse.Moves = startCoordinatesMove.Moves;
                    moveResponse.StartCoordinates = startCoordinatesMove.StartCoordinates;

                    result.Add(moveResponse);
                }
            }

            return result;
        }




        private void SpinNinetyToLeftDegrees(Hover hover)
        {
            hover.Direction = hover.Direction switch
            {
                Ways.N => Ways.W,
                Ways.W => Ways.S,
                Ways.S => Ways.E,
                _ => Ways.N
            };
        }

        private void SpinNinetyToRightDegrees(Hover hover)
        {
            hover.Direction = hover.Direction switch
            {
                Ways.N => Ways.E,
                Ways.W => Ways.N,
                Ways.S => Ways.W,
                _ => Ways.S
            };
        }

        private void MoveForward(Hover hover)
        {
            switch (hover.Direction)
            {
                case Ways.N:
                    hover.Y++;
                    break;
                case Ways.W:
                    hover.X--;
                    break;
                case Ways.S:
                    hover.Y--;
                    break;
                case Ways.E:
                    hover.X++;
                    break;

            }
        }



    }


}
