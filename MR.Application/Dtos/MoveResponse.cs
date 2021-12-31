using System.Text.Json.Serialization;

namespace MR.Application.Dtos
{
    public class MoveResponse
    {
        public string[] StartCoordinates { get; set; }

        public string Moves { get; set; }
        public string FinalCoordinates { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string> ErrorMessages { get; set; } = new();
    }
}
