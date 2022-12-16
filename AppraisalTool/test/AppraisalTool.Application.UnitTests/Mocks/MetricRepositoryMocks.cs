using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.UnitTests.Mocks
{
    public class MetricRepositoryMocks
    {
        public static Mock<IMetricRepository> GetAllListOfMetircs()
        {
            var mertrics = new List<ListOfMetrics>
            {
                new ListOfMetrics
                {
                    Metric_ID=1,
                    List_Id=1,
                    Metric_Description="Ability to handle autonomy",
                    metric_Weightage=5

                },
                new ListOfMetrics
                {
                    Metric_ID=2,
                    List_Id=1,
                    Metric_Description="Discipline & Punctuality",
                    metric_Weightage=5

                },
                new ListOfMetrics
                {
                    Metric_ID=3,
                    List_Id=1,
                    Metric_Description="Decision Making",
                    metric_Weightage=5

                },
                new ListOfMetrics
                {
                    Metric_ID=4,
                    List_Id=1,
                    Metric_Description="Leadership & Mentoring",
                    metric_Weightage=5

                },
                new ListOfMetrics
                {
                    Metric_ID=5,
                    List_Id=3,
                    Metric_Description="Collaboration",
                    metric_Weightage=5

                },
                new ListOfMetrics
                {
                    Metric_ID=6,
                    List_Id=3,
                    Metric_Description="Digital mindset",
                    metric_Weightage=5

                },
                new ListOfMetrics
                {
                    Metric_ID=7,
                    List_Id=3,
                    Metric_Description="Communication",
                    metric_Weightage=5

                },
            };
            var mockMetricRepository= new Mock<IMetricRepository>();
            mockMetricRepository.Setup(x => x.ListAllAsync()).ReturnsAsync(mertrics);
            return mockMetricRepository;
        }

    }
}
