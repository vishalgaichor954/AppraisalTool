using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AppraisalTool.Application.Features.FinancialYears.Command.UpdateFinancialYearCommand
{
    public class UpdateFinancialYearCommandHandler : IRequestHandler<UpdateFinanacialYearCommand, Response<UpdateFinancialYearCommandDto>>
    {
        private readonly IFinacialYearRepository _finacialYearRepository;
        public UpdateFinancialYearCommandHandler(IFinacialYearRepository finacialYearRepository)
        {
            _finacialYearRepository= finacialYearRepository;
        }
        public async Task<Response<UpdateFinancialYearCommandDto>> Handle(UpdateFinanacialYearCommand request, CancellationToken cancellationToken)
        {
            var FyDto = await _finacialYearRepository.UpdateFinancialYearAsync(request.Id, request);
            if (FyDto.Succeeded)
            {
                return new Response<UpdateFinancialYearCommandDto>(FyDto, "Success");
            }
            else
            {
                var res = new Response<UpdateFinancialYearCommandDto>(FyDto, "Failed");
                res.Succeeded = false;
                return res;

            }
        }
    }
}
