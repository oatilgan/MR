using MR.Application.Dtos;

namespace MR.Application.Contracts
{
    public interface IMoveHover
    {
        List<MoveResponse> Move(List<MoveRequest> request);
    }
}
