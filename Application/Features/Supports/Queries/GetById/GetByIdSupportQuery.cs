using MediatR;

namespace Application.Features.Supports.Queries.GetById;

public  class GetByIdSupportQuery : IRequest<GetByIdSupportResponse>
{
    public int Id { get; set; }
}
