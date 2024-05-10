using CQRS.Entities.Dtos.Responses;
using MediatR;

namespace CQRS.Api.Queries
{
    public class GetDriverQuery : IRequest<GetDriverResponse>
    {
        public Guid DriverId { get; }

        public GetDriverQuery(Guid driverId)
        {
            DriverId = driverId;  
        }
    }
}
