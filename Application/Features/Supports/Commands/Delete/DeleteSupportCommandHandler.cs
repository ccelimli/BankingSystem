using Application.Features.Supports.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Supports.Commands.Delete;
public class DeleteSupportCommandHandler : IRequestHandler<DeleteSupportCommand, DeleteSupportResponse>
{
    private readonly ISupportRepository _supportRepository;
    private readonly IMapper _mapper;
    private readonly SupportBusinessRules _supportBusinessRules;

    public DeleteSupportCommandHandler(ISupportRepository supportRepository, IMapper mapper, SupportBusinessRules supportBusinessRules)
    {
        _supportRepository = supportRepository;
        _mapper = mapper;
        _supportBusinessRules = supportBusinessRules;
    }

    public async Task<DeleteSupportResponse> Handle(DeleteSupportCommand request, CancellationToken cancellationToken)
    {
        await _supportBusinessRules.SupportMustBePresent(request.Id);

        Support? support = await _supportRepository.GetAsync(predicate: support => support.Id == request.Id, cancellationToken: cancellationToken);
        await _supportRepository.DeleteAsync(support);
        DeleteSupportResponse response = _mapper.Map<DeleteSupportResponse>(support);

        return response;
    }
}
