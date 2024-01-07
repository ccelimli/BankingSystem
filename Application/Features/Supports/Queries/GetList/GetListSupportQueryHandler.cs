using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Supports.Queries.GetList;

public class GetListSupportQueryHandler : IRequestHandler<GetListSupportQuery, GetListResponse<GetListSupportListItemResponse>>
{
    private readonly ISupportRepository _supportRepository;
    private readonly IMapper _mapper;

    public GetListSupportQueryHandler(ISupportRepository supportRepository, IMapper mapper)
    {
        _supportRepository = supportRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListSupportListItemResponse>> Handle(GetListSupportQuery request, CancellationToken cancellationToken)
    {
        Paginate<Support> supports = await _supportRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: support => support.Include(support => support.User),
                cancellationToken: cancellationToken
            );
        GetListResponse<GetListSupportListItemResponse> response = _mapper.Map<GetListResponse<GetListSupportListItemResponse>>(supports);

        return response;
    }
}
