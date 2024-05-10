using AutoMapper;
using CQRS.Api.Queries;
using CQRS.DataService.Repositories.Interfaces;
using CQRS.Entities.Dtos.Responses;
using MediatR;

namespace CQRS.Api.Handlers
{
    public class GetAllDriversHandler : IRequestHandler<GetAllDriversQuery, IEnumerable<GetDriverResponse>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllDriversHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetDriverResponse>> Handle(GetAllDriversQuery request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.Drivers.All();

            return _mapper.Map<IEnumerable<GetDriverResponse>>(driver);
        }
    }
}
