using Application.Features.Credit.Commands.Create;
using Application.Features.Loans.Commands.Create;
using Application.Features.Loans.Commands.Delete;
using Application.Features.Loans.Commands.Update;
using Application.Features.Loans.Queries.GetById;
using Application.Features.Loans.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateLoanCommand createLoanCommand) {
            CreateLoanResponse createLoanResponse = await Mediator.Send(createLoanCommand);
            return Created("Success", createLoanResponse);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateLoanCommand updateLoanCommand)
        {
            UpdateLoanResponse updateLoanResponse = await Mediator.Send(updateLoanCommand);
            return Created("Success", updateLoanResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListLoanQuery getListLoanQuery = new GetListLoanQuery() { PageRequest = pageRequest };
            GetListResponse<GetListLoanListResponse> getListLoanListResponse = await Mediator.Send(getListLoanQuery);
            return Created("Success", getListLoanListResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            GetByIdLoanQuery getByIdLoanQuery = new GetByIdLoanQuery() { Id = id};
            GetByIdLoanResponse getByIdLoanResponse = await Mediator.Send(getByIdLoanQuery);
            return Created("Success", getByIdLoanResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteLoanCommand deleteLoanCommand = new DeleteLoanCommand() { Id = id };
            DeleteLoanResponse deleteLoanResponse = await Mediator.Send(deleteLoanCommand);
            return Created("Success", deleteLoanResponse);
        }


    }
}
