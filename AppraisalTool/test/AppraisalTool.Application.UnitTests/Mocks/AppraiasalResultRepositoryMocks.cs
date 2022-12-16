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
    public class AppraiasalResultRepositoryMocks
    {
        public static Mock<IAppraisalResultRepository> GetAppraisalResultByFidUid()
        {
            var appraisalResult = new List<AppraisalResult>
            {
                new AppraisalResult
                {
                    ID=631,
                    UserId=1,
                    KraListId=1,
                    MetricId=1,
                    AppraisalId=96,
                    MetricDescription="Ability to handle autonomy",
                    MetricWeightage=5,
                    SelfScore=2,
                    SelfComment="TEST1 @ RISHI SELF COMMENT",
                    SelfCreatatedDate=DateTime.Now,
                    RepaSelfScore=3,
                    RepaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RepaSelfCreatatedDate=DateTime.Now,
                    RevaSelfScore=4,
                    RevaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RevaSelfCreatatedDate=DateTime.Now,

                },
                new AppraisalResult
                {
                    ID=632,
                    UserId=1,
                    KraListId=1,
                    MetricId=1,
                    AppraisalId=96,
                    MetricDescription="Ability to handle autonomy",
                    MetricWeightage=5,
                    SelfScore=2,
                    SelfComment="TEST1 @ RISHI SELF COMMENT",
                    SelfCreatatedDate=DateTime.Now,
                    RepaSelfScore=3,
                    RepaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RepaSelfCreatatedDate=DateTime.Now,
                    RevaSelfScore=4,
                    RevaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RevaSelfCreatatedDate=DateTime.Now,

                },
                new AppraisalResult
                {
                    ID=633,
                    UserId=1,
                    KraListId=1,
                    MetricId=1,
                    AppraisalId=96,
                    MetricDescription="Ability to handle autonomy",
                    MetricWeightage=5,
                    SelfScore=2,
                    SelfComment="TEST1 @ RISHI SELF COMMENT",
                    SelfCreatatedDate=DateTime.Now,
                    RepaSelfScore=3,
                    RepaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RepaSelfCreatatedDate=DateTime.Now,
                    RevaSelfScore=4,
                    RevaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RevaSelfCreatatedDate=DateTime.Now,

                },
                new AppraisalResult
                {
                    ID=634,
                    UserId=1,
                    KraListId=1,
                    MetricId=1,
                    AppraisalId=96,
                    MetricDescription="Ability to handle autonomy",
                    MetricWeightage=5,
                    SelfScore=2,
                    SelfComment="TEST1 @ RISHI SELF COMMENT",
                    SelfCreatatedDate=DateTime.Now,
                    RepaSelfScore=3,
                    RepaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RepaSelfCreatatedDate=DateTime.Now,
                    RevaSelfScore=4,
                    RevaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RevaSelfCreatatedDate=DateTime.Now,

                },
                new AppraisalResult
                {
                    ID=634,
                    UserId=1,
                    KraListId=1,
                    MetricId=1,
                    AppraisalId=96,
                    MetricDescription="Ability to handle autonomy",
                    MetricWeightage=5,
                    SelfScore=2,
                    SelfComment="TEST1 @ RISHI SELF COMMENT",
                    SelfCreatatedDate=DateTime.Now,
                    RepaSelfScore=3,
                    RepaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RepaSelfCreatatedDate=DateTime.Now,
                    RevaSelfScore=4,
                    RevaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RevaSelfCreatatedDate=DateTime.Now,

                },
                new AppraisalResult
                {
                    ID=635,
                    UserId=1,
                    KraListId=1,
                    MetricId=1,
                    AppraisalId=96,
                    MetricDescription="Ability to handle autonomy",
                    MetricWeightage=5,
                    SelfScore=2,
                    SelfComment="TEST1 @ RISHI SELF COMMENT",
                    SelfCreatatedDate=DateTime.Now,
                    RepaSelfScore=3,
                    RepaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RepaSelfCreatatedDate=DateTime.Now,
                    RevaSelfScore=4,
                    RevaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RevaSelfCreatatedDate=DateTime.Now,

                },
                new AppraisalResult
                {
                    ID=636,
                    UserId=1,
                    KraListId=1,
                    MetricId=1,
                    AppraisalId=96,
                    MetricDescription="Ability to handle autonomy",
                    MetricWeightage=5,
                    SelfScore=2,
                    SelfComment="TEST1 @ RISHI SELF COMMENT",
                    SelfCreatatedDate=DateTime.Now,
                    RepaSelfScore=3,
                    RepaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RepaSelfCreatatedDate=DateTime.Now,
                    RevaSelfScore=4,
                    RevaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RevaSelfCreatatedDate=DateTime.Now,

                },
                new AppraisalResult
                {
                    ID=637,
                    UserId=1,
                    KraListId=1,
                    MetricId=1,
                    AppraisalId=96,
                    MetricDescription="Ability to handle autonomy",
                    MetricWeightage=5,
                    SelfScore=2,
                    SelfComment="TEST1 @ RISHI SELF COMMENT",
                    SelfCreatatedDate=DateTime.Now,
                    RepaSelfScore=3,
                    RepaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RepaSelfCreatatedDate=DateTime.Now,
                    RevaSelfScore=4,
                    RevaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RevaSelfCreatatedDate=DateTime.Now,

                },
                new AppraisalResult
                {
                    ID=638,
                    UserId=1,
                    KraListId=1,
                    MetricId=1,
                    AppraisalId=96,
                    MetricDescription="Ability to handle autonomy",
                    MetricWeightage=5,
                    SelfScore=2,
                    SelfComment="TEST1 @ RISHI SELF COMMENT",
                    SelfCreatatedDate=DateTime.Now,
                    RepaSelfScore=3,
                    RepaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RepaSelfCreatatedDate=DateTime.Now,
                    RevaSelfScore=4,
                    RevaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RevaSelfCreatatedDate=DateTime.Now,

                },
                new AppraisalResult
                {
                    ID=639,
                    UserId=1,
                    KraListId=1,
                    MetricId=1,
                    AppraisalId=96,
                    MetricDescription="Ability to handle autonomy",
                    MetricWeightage=5,
                    SelfScore=2,
                    SelfComment="TEST1 @ RISHI SELF COMMENT",
                    SelfCreatatedDate=DateTime.Now,
                    RepaSelfScore=3,
                    RepaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RepaSelfCreatatedDate=DateTime.Now,
                    RevaSelfScore=4,
                    RevaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RevaSelfCreatatedDate=DateTime.Now,

                },
                new AppraisalResult
                {
                    ID=640,
                    UserId=1,
                    KraListId=1,
                    MetricId=1,
                    AppraisalId=96,
                    MetricDescription="Ability to handle autonomy",
                    MetricWeightage=5,
                    SelfScore=2,
                    SelfComment="TEST1 @ RISHI SELF COMMENT",
                    SelfCreatatedDate=DateTime.Now,
                    RepaSelfScore=3,
                    RepaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RepaSelfCreatatedDate=DateTime.Now,
                    RevaSelfScore=4,
                    RevaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RevaSelfCreatatedDate=DateTime.Now,

                },
                new AppraisalResult
                {
                    ID=641,
                    UserId=1,
                    KraListId=1,
                    MetricId=1,
                    AppraisalId=96,
                    MetricDescription="Ability to handle autonomy",
                    MetricWeightage=5,
                    SelfScore=2,
                    SelfComment="TEST1 @ RISHI SELF COMMENT",
                    SelfCreatatedDate=DateTime.Now,
                    RepaSelfScore=3,
                    RepaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RepaSelfCreatatedDate=DateTime.Now,
                    RevaSelfScore=4,
                    RevaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RevaSelfCreatatedDate=DateTime.Now,

                },
                new AppraisalResult
                {
                    ID=642,
                    UserId=1,
                    KraListId=1,
                    MetricId=1,
                    AppraisalId=96,
                    MetricDescription="Ability to handle autonomy",
                    MetricWeightage=5,
                    SelfScore=2,
                    SelfComment="TEST1 @ RISHI SELF COMMENT",
                    SelfCreatatedDate=DateTime.Now,
                    RepaSelfScore=3,
                    RepaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RepaSelfCreatatedDate=DateTime.Now,
                    RevaSelfScore=4,
                    RevaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RevaSelfCreatatedDate=DateTime.Now,

                },
                new AppraisalResult
                {
                    ID=643,
                    UserId=1,
                    KraListId=1,
                    MetricId=1,
                    AppraisalId=96,
                    MetricDescription="Ability to handle autonomy",
                    MetricWeightage=5,
                    SelfScore=2,
                    SelfComment="TEST1 @ RISHI SELF COMMENT",
                    SelfCreatatedDate=DateTime.Now,
                    RepaSelfScore=3,
                    RepaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RepaSelfCreatatedDate=DateTime.Now,
                    RevaSelfScore=4,
                    RevaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RevaSelfCreatatedDate=DateTime.Now,

                },
                new AppraisalResult
                {
                    ID=644,
                    UserId=1,
                    KraListId=1,
                    MetricId=1,
                    AppraisalId=96,
                    MetricDescription="Ability to handle autonomy",
                    MetricWeightage=5,
                    SelfScore=2,
                    SelfComment="TEST1 @ RISHI SELF COMMENT",
                    SelfCreatatedDate=DateTime.Now,
                    RepaSelfScore=3,
                    RepaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RepaSelfCreatatedDate=DateTime.Now,
                    RevaSelfScore=4,
                    RevaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RevaSelfCreatatedDate=DateTime.Now,

                },
                new AppraisalResult
                {
                    ID=645,
                    UserId=1,
                    KraListId=1,
                    MetricId=1,
                    AppraisalId=96,
                    MetricDescription="Ability to handle autonomy",
                    MetricWeightage=5,
                    SelfScore=2,
                    SelfComment="TEST1 @ RISHI SELF COMMENT",
                    SelfCreatatedDate=DateTime.Now,
                    RepaSelfScore=3,
                    RepaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RepaSelfCreatatedDate=DateTime.Now,
                    RevaSelfScore=4,
                    RevaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RevaSelfCreatatedDate=DateTime.Now,

                },
                new AppraisalResult
                {
                    ID=646,
                    UserId=1,
                    KraListId=1,
                    MetricId=1,
                    AppraisalId=96,
                    MetricDescription="Ability to handle autonomy",
                    MetricWeightage=5,
                    SelfScore=2,
                    SelfComment="TEST1 @ RISHI SELF COMMENT",
                    SelfCreatatedDate=DateTime.Now,
                    RepaSelfScore=3,
                    RepaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RepaSelfCreatatedDate=DateTime.Now,
                    RevaSelfScore=4,
                    RevaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RevaSelfCreatatedDate=DateTime.Now,

                },
                new AppraisalResult
                {
                    ID=647,
                    UserId=1,
                    KraListId=1,
                    MetricId=1,
                    AppraisalId=96,
                    MetricDescription="Ability to handle autonomy",
                    MetricWeightage=5,
                    SelfScore=2,
                    SelfComment="TEST1 @ RISHI SELF COMMENT",
                    SelfCreatatedDate=DateTime.Now,
                    RepaSelfScore=3,
                    RepaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RepaSelfCreatatedDate=DateTime.Now,
                    RevaSelfScore=4,
                    RevaSelfComment="TEST@NEW REPA FORM FROM hARI",
                    RevaSelfCreatatedDate=DateTime.Now,

                },

            };
            var appraisal = new List<Appraisal>
            {
                new Appraisal
                {
                   Id=96,
                   FinancialYearId=2,
                   UserId=1,
                   StartDate=DateTime.Now,
                   EndDate=DateTime.Now,
                   StatusId=4,


                }
            };
            var apprisal = appraisal.FirstOrDefault(x => x.UserId == 1 && x.FinancialYearId == 2);

            var mockAppraiasalResultRepository = new Mock<IAppraisalResultRepository>();
            mockAppraiasalResultRepository.Setup(repo => repo.GetAprraisalResultData(2, 1)).ReturnsAsync(appraisalResult.Where(x => x.AppraisalId == apprisal.Id).ToList());
            return mockAppraiasalResultRepository;
        }
    }
}
