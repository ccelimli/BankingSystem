using Application.Features.MoneyTransactions.Commands.WithdrawMoney;
using Application.Features.MoneyTransactions.Commands.DepositMoney;
using Application.Features.MoneyTransactions.Commands.MoneyTransfer;
using Microsoft.AspNetCore.Mvc;
using Application.Features.MoneyTransactions.Commands.LoanDeptPayment;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyTransactionController : BaseController
    {
        [HttpPost("depositMoney")]
        public async Task<IActionResult> DepositMoneyTransaction([FromBody] DepositMoneyTransactionCommand moneyTransactionCommand)
        {
            DepositMoneyTransactionResponse response = await Mediator.Send(moneyTransactionCommand);

            return Ok(response);
        }

        [HttpPost("withdrawMoney")]
        public async Task<IActionResult> WithdrawMoneyTransaction([FromBody] WithdrawMoneyTransactionCommand moneyTransactionCommand)
        {
            WithdrawMoneyTransactionResponse response = await Mediator.Send(moneyTransactionCommand);

            return Ok(response);
        }

        [HttpPost("MoneyTransaction")]
        public async Task<IActionResult> MoneyTransaction([FromBody] MoneyTransactionCommand moneyTransactionCommand)
        {
            MoneyTransactionResponse response = await Mediator.Send(moneyTransactionCommand);

            return Ok(response);
        }

        [HttpPost("LoanDeptPayment")]
        public async Task<IActionResult> LoanDeptPayment([FromBody] LoanDeptPaymentCommand loanDeptPaymentCommand)
        {
            LoanDeptPaymentResponse response = await Mediator.Send(loanDeptPaymentCommand);

            return Ok(response);
        }
    }
}
