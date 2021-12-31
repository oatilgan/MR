using System.Collections.Generic;
using System.Text.Json;
using MR.Application.Dtos;
using MR.Application.Features;
using Xunit;

namespace Test
{
    public class HoverTest
    {
        private readonly MoveHover _moveHover;
        public HoverTest()
        {
            _moveHover = new MoveHover();
        }

        [Fact]
        public void Move_12N_LMLMLMLMM()
        {
            var moveRequests = new List<MoveRequest>()
            {
                new(new List<int>(){5,5},


                     new List<StartCoordinatesMoves>()
                    {
                        new()
                        {
                            Moves = "LMLMLMLMM",
                            StartCoordinates =new []{ "1","2","N"}
                        }
                    }
                )
            };
            var actual = _moveHover.Move(moveRequests);

            var expected = new List<MoveResponse>()
         {
             new()
             {
                 StartCoordinates = new []{"1","2","N"},
                 Moves = "LMLMLMLMM",
                 FinalCoordinates = "1 3 N",
                 ErrorMessages = null
             }
         };

            var jsonActual = JsonSerializer.Serialize(actual);
            var jsonExpected = JsonSerializer.Serialize(expected);

            Assert.Equal(jsonExpected, jsonActual);
        }

        [Fact]
        public void Move_33E_MMRMMRMRRM()
        {
            var moveRequests = new List<MoveRequest>()
            {
                new(new List<int>(){5,5},


                    new List<StartCoordinatesMoves>()
                    {
                        new()
                        {
                            Moves = "MMRMMRMRRM",
                            StartCoordinates =new []{ "3","3","E"}
                        }
                    }
                )
            };
            var actual = _moveHover.Move(moveRequests);

            var expected = new List<MoveResponse>()
            {
                new()
                {
                    StartCoordinates = new []{"3","3","E"},
                    Moves = "MMRMMRMRRM",
                    FinalCoordinates = "5 1 E",
                    ErrorMessages = null
                }
            };

            var jsonActual = JsonSerializer.Serialize(actual);
            var jsonExpected = JsonSerializer.Serialize(expected);

            Assert.Equal(jsonExpected, jsonActual);
        }


        [Fact]
        public void Move_12N5_KLLMM()
        {
            var moveRequests = new List<MoveRequest>()
            {
                new(new List<int>(){5,5},


                    new List<StartCoordinatesMoves>()
                    {
                        new()
                        {
                            Moves = "KLLMM",
                            StartCoordinates =new []{ "1","2","N","5"}
                        }
                    }
                )
            };
            var actual = _moveHover.Move(moveRequests);

            var expected = new List<MoveResponse>()
            {
                new()
                {
                    StartCoordinates = new []{"1","2","N","5"},
                    Moves = "KLLMM",
                    FinalCoordinates = "-2 0 W",
                    ErrorMessages = new List<string>()
                    {
                        "Start Coordinates are wrong",
                        " Invalid way",
                        " Exceeded given coordinates 5, 5",
                        " Exceeded given coordinates 5, 5"
                    }
                }
            };

            var jsonActual = JsonSerializer.Serialize(actual);
            var jsonExpected = JsonSerializer.Serialize(expected);

            Assert.Equal(jsonExpected, jsonActual);
        }
    }
}