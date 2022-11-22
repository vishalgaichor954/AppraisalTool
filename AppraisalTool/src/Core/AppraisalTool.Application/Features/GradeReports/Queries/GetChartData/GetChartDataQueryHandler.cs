using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.FinancialYears.Queries.GetAllFinancialYears;
using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Common;
using AppraisalTool.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.GradeReports.Queries.GetChartData
{
    public class GetChartDataQueryHandler : IRequestHandler<GetChartDataQuery, Response<GradeChartsData>>
    {

        private readonly ISelfAppraisalRepository _selfAppraisalRepository;
        private readonly IAppraisalResultRepository _appraisalResultRepository;
        private readonly IMapper _mapper;

        public GetChartDataQueryHandler(ISelfAppraisalRepository selfAppraisalRepository, IMapper mapper, IAppraisalResultRepository appraisalResultRepository)
        {
            _selfAppraisalRepository = selfAppraisalRepository;
            _appraisalResultRepository = appraisalResultRepository;
            _mapper = mapper;
        }

        public async Task<Response<GradeChartsData>> Handle(GetChartDataQuery request, CancellationToken cancellationToken)
        {
            Appraisal appraisal = await _selfAppraisalRepository.GetAppraisalByUserAndFinancialYear(request.FinancialYearId, request.UserId);
            if (appraisal != null)
            {
                List<AppraisalResult> results = await _appraisalResultRepository.GetAppraisalResultsByApppraisalId(appraisal.Id);

                int totalWeightage = 0;
                int totalObtainedScore = 0;
                int inputMetricWeightage = 0;
                int inputMetricObtainedScore = 0;
                int behavMetricWeightage = 0;
                int behaviouralMetricObtainedScore = 0;
                int jobGroomingMetricWeightage = 0;
                int jobGroomingMetricObtainedScore = 0;

                GradeChartsData data = new GradeChartsData() { FinancialStartYear = appraisal.FinancialYear.StartYear, FinancialEndYear = appraisal.FinancialYear.EndYear };

                results.ForEach(item =>
                {
                    totalWeightage += (int)item.MetricWeightage;
                    totalObtainedScore += (int)item.RevaSelfScore;

                    if (item.KraListId.Equals(1))
                    {
                        inputMetricWeightage += (int)item.MetricWeightage;
                        inputMetricObtainedScore += (int)item.RevaSelfScore;
                    }
                    else if (item.KraListId.Equals(3))
                    {
                        behavMetricWeightage += (int)item.MetricWeightage;
                        behaviouralMetricObtainedScore += (int)item.RevaSelfScore;
                    }
                    else if (item.KraListId.Equals(4))
                    {
                        jobGroomingMetricWeightage += (int)item.MetricWeightage;
                        jobGroomingMetricObtainedScore += (int)item.RevaSelfScore;
                    }
                });
                data.TotalObtainedScore = totalObtainedScore;
                data.TotalWeightage = totalWeightage;
                data.InputMetricWeightage = inputMetricWeightage;
                data.InputMetricObtainedScore = inputMetricObtainedScore;
                data.BehaviouralMetricWeightage = behavMetricWeightage;
                data.BehaviouralMetricObtainedScore = behaviouralMetricObtainedScore;
                data.JobGroomingMetricWeightage = jobGroomingMetricWeightage;
                data.JobGroomingMetricObtainedScore = jobGroomingMetricObtainedScore;      
                return new Response<GradeChartsData>(data);
            }
            else
            {
                return new Response<GradeChartsData>() { Message="No Appraisal Found", Succeeded = false,Data=null };
            }
        }
    }
}
