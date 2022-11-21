using AppraisalTool.App.Helpers;
using AppraisalTool.App.Models;
using AppraisalTool.App.Models.AppraisalToolAuth;
using AppraisalTool.App.Models.GradeReport;
using DinkToPdf;
using IronPdf;
using jsreport.Binary;
using jsreport.Local;
using jsreport.Types;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Syncfusion.EJ2.CircularGauge;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using PaperKind = DinkToPdf.PaperKind;

namespace AppraisalTool.App.Controllers
{
    public class GradeReportController : Controller
    {
        private readonly ILogger<GradeReportController> _logger;
        Uri baseAddress = new Uri("https://localhost:5000/api/v1");
        HttpClient client;
        //Uri baseAddress = new Uri("https://localhost:5000/api");
        public GradeReportController(ILogger<GradeReportController> logger)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            _logger = logger;

        }

        //Author : Ilyas Dabholkar
        public IActionResult ViewGradeReport(int Fid)
        {
            List<CircularGaugePointer> pointers = new List<CircularGaugePointer>();
            CircularGaugePointer pointer1 = new CircularGaugePointer();
            pointer1.Value = 70;
            pointer1.Radius = "60%";
            pointer1.PointerWidth = 8;
            pointer1.Cap = new CircularGaugeCap
            {
                Radius = 7
            };
            pointer1.NeedleTail = new CircularGaugeNeedleTail
            {
                Length = "18%"
            };
            pointers.Add(pointer1);
            ViewBag.Pointers = pointers;

            // Ranges //
            List<CircularGaugeRange> ranges = new List<CircularGaugeRange>();
            CircularGaugeRange range1 = new CircularGaugeRange();
            range1.Start = 0;
            range1.End = 5;
            range1.Color = "#ccffff";
            range1.Radius = "110%";
            range1.LegendText = "Light air";
            ranges.Add(range1);

            CircularGaugeRange range2 = new CircularGaugeRange();
            range2.Start = 5;
            range2.End = 11;
            range2.Color = "#99ffff";
            range2.Radius = "110%";
            range2.LegendText = "Light breeze";
            ranges.Add(range2);

            CircularGaugeRange range3 = new CircularGaugeRange();
            range3.Start = 11;
            range3.End = 19;
            range3.Color = "#99ff99";
            range3.Radius = "110%";
            range3.LegendText = "Gentle breeze";
            ranges.Add(range3);

            CircularGaugeRange range4 = new CircularGaugeRange();
            range4.Start = 19;
            range4.End = 28;
            range4.Color = "#79ff4d";
            range4.Radius = "110%";
            range4.LegendText = "Moderate breeze";
            ranges.Add(range4);

            CircularGaugeRange range5 = new CircularGaugeRange();
            range5.Start = 28;
            range5.End = 49;
            range5.Color = "#c6ff1a";
            range5.Radius = "110%";
            range5.LegendText = "Strong breeze";
            ranges.Add(range5);

            CircularGaugeRange range6 = new CircularGaugeRange();
            range6.Start = 49;
            range6.End = 74;
            range6.Color = "#e6ac00";
            range6.Radius = "110%";
            range6.LegendText = "Gale";
            ranges.Add(range6);

            CircularGaugeRange range7 = new CircularGaugeRange();
            range7.Start = 74;
            range7.End = 102;
            range7.Color = "#ff6600";
            range7.Radius = "110%";
            range7.LegendText = "Storm";
            ranges.Add(range7);

            CircularGaugeRange range8 = new CircularGaugeRange();
            range8.Start = 102;
            range8.End = 120;
            range8.Color = "#ff0000";
            range8.Radius = "110%";
            range8.LegendText = "Hurricane force";
            ranges.Add(range8);
            ViewBag.Ranges = ranges;

            var user = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");

            HttpResponseMessage httpResponseMessage = client.GetAsync(client.BaseAddress + $"/GradeReport/GetChartsData?Fid={Fid}&userId={user.UserId}").Result;

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var responseData = httpResponseMessage.Content.ReadAsStringAsync().Result;
                var res = JsonConvert.DeserializeObject<Response>(responseData);

                GradeChartsData gradeData = JsonConvert.DeserializeObject<GradeChartsData>(JsonConvert.SerializeObject(res.Data));
                double totalPercentageScored = (double)gradeData.TotalObtainedScore / gradeData.TotalWeightage;
                double InputMetricPercentage = (double)gradeData.InputMetricObtainedScore / gradeData.InputMetricWeightage;
                double BehavioralMetricPercentage = (double)gradeData.BehaviouralMetricObtainedScore / gradeData.BehaviouralMetricWeightage;
                double JobGroomingMetricPercentage = (double)gradeData.JobGroomingMetricObtainedScore / gradeData.JobGroomingMetricWeightage;
                gradeData.totatScoredPercentage = (int)Math.Round(totalPercentageScored * 70);
                gradeData.totatInputMetricScoredPercentage = (int)Math.Round(InputMetricPercentage * 100);
                gradeData.totatBehaviouralMetricScoredPercentage = (int)Math.Round(BehavioralMetricPercentage * 100);
                gradeData.totatJobGromingMetricScoredPercentage = (int)Math.Round(JobGroomingMetricPercentage * 100);


                Console.WriteLine(gradeData);

                return View(gradeData);
            }

            return View();

        }

       [HttpPost]
        public async Task<ActionResult> ExportPdf(string ExportData)
       {


            var rs = new LocalReporting()
               .KillRunningJsReportProcesses()
               .UseBinary(RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? JsReportBinary.GetBinary() : jsreport.Binary.Linux.JsReportBinary.GetBinary())
               .Configure(cfg => cfg.AllowedLocalFilesAccess().FileSystemStore().BaseUrlAsWorkingDirectory())
               .AsUtility()
               .Create();
            var generatedPdf = await rs.RenderAsync(new RenderRequest
            {
                Template = new Template
                {
                    Recipe = Recipe.ChromePdf,
                    Engine = Engine.None,
                    Content = ExportData,
                    Chrome = new Chrome
                    {
                        MarginTop = "10",
                        MarginBottom = "10",
                        MarginLeft = "50",
                        MarginRight = "50"
                    }
                }
            });
            return File(generatedPdf.Content, generatedPdf.Meta.ContentType, "GeneratedPdfFile.pdf");



        }
    }
}
