using MR.Domain.Enums;

namespace MR.Domain.Entities
{
    public class Hover
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Ways Direction { get; set; }

        //public void SpinNinetyToLeftDegrees()
        //{
        //    Direction = Direction switch
        //    {
        //        Ways.N => Ways.W,
        //        Ways.W => Ways.S,
        //        Ways.S => Ways.E,
        //        _ => Ways.N
        //    };
        //}

        //public void SpinNinetyToRightDegrees()
        //{
        //    Direction = Direction switch
        //    {
        //        Ways.N => Ways.E,
        //        Ways.W => Ways.N,
        //        Ways.S => Ways.W,
        //        _ => Ways.S
        //    };
        //}

        //public void MoveForward()
        //{
        //    switch (Direction)
        //    {
        //        case Ways.N:
        //            Y++;
        //            break;
        //        case Ways.W:
        //            X--;
        //            break;
        //        case Ways.S:
        //            Y--;
        //            break;
        //        case Ways.E:
        //            X++;
        //            break;

        //    }
        //}
        //public void Move(string moves, List<int> maxCoordinates)
        //{
        //    var result = string.Empty;
        //    foreach (var move in moves)
        //    {
        //        switch (move)
        //        {
        //            case 'R':
        //                SpinNinetyToRightDegrees();
        //                break;
        //            case 'L':
        //                SpinNinetyToLeftDegrees();
        //                break;
        //            case 'M':
        //                MoveForward();
        //                break;
        //            default:
        //                throw new Exception("Invalid way");
        //        }

        //        if (X < 0 || X > maxCoordinates[0] || Y < 0 || Y > maxCoordinates[1])
        //        {
        //           throw new Exception($"Oops! Position can not be beyond bounderies (0 , 0) and ({maxCoordinates[0]} , {maxCoordinates[1]}) Last Position: {X} {Y} {Direction}");

        //        }
        //    }
            
        //}
    }
}
