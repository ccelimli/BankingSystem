using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Requests;
using Domain.Entities;
using MediatR;

namespace Application.Features.MoneyTransactions.Queries.GetById;

public partial class GetByIdMoneyTransactionQuery
{
    public class GetByIdMoneyTransactionQueryHandler : IRequestHandler<GetByIdMoneyTransactionQuery, GetByIdMoneyTransactionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMoneyTransactionRepository _moneyTransactionRepository;

       

        public GetByIdMoneyTransactionQueryHandler(IMapper mapper, IMoneyTransactionRepository moneyTransactionRepository)
        {
            _mapper = mapper;
            _moneyTransactionRepository = moneyTransactionRepository;
        }

        public async Task<GetByIdMoneyTransactionResponse> Handle(GetByIdMoneyTransactionQuery request, CancellationToken cancellationToken)
        {
            MoneyTransaction? brand = await _moneyTransactionRepository.GetAsync(predicate: b => b.Id == request.Id, withDeleted: true, cancellationToken: cancellationToken);

            GetByIdMoneyTransactionResponse response = _mapper.Map<GetByIdMoneyTransactionResponse>(brand);

            return response;
        }
    }


}