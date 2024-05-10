using CQRS.Entities.Dtos.Responses;
using MediatR;

namespace CQRS.Api.Queries
{
    public class GetAllDriversQuery :IRequest<IEnumerable<GetDriverResponse>>
    {
    }
}
