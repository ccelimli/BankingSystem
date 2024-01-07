using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MoneyTransactions.Queries.GetList;

public class GetListMoneyTransactionQuery : IRequest<GetListResponse<GetListMoneyTransactionDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListBrandQueryHandler : IRequestHandler<GetListMoneyTransactionQuery, GetListResponse<GetListMoneyTransactionDto>>
    {
        private readonly IMoneyTransactionRepository _moneyTransactionRepository;
        private readonly IMapper _mapper;

        public GetListBrandQueryHandler(IMoneyTransactionRepository moneyTransactionRepository, IMapper mapper)
        {
            _moneyTransactionRepository = moneyTransactionRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMoneyTransactionDto>> Handle(GetListMoneyTransactionQuery request, CancellationToken cancellationToken)
        {
            Paginate<MoneyTransaction> moneyTransactions = await _moneyTransactionRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken,
                withDeleted: true
                );

            GetListResponse<GetListMoneyTransactionDto> response = _mapper.Map<GetListResponse<GetListMoneyTransactionDto>>(moneyTransactions);
            return response;

        }
    }
}