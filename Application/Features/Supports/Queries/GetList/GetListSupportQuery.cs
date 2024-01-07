using Core.Application.Requests;
using Core.Application.Responses;
using MediatR;

namespace Application.Features.Supports.Queries.GetList;

public partial class GetListSupportQuery : IRequest<GetListResponse<GetListSupportListItemResponse>>
{
    public PageRequest PageRequest { get; set; }
}
