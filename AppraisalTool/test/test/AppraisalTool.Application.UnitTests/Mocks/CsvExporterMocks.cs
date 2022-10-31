using CsvHelper;
using AppraisalTool.Application.Contracts.Infrastructure;
using AppraisalTool.Application.Features.Events.Queries.GetEventsExport;
using Moq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace AppraisalTool.Application.UnitTests.Mocks
{
    public class CsvExporterMocks
    {
        public static Mock<ICsvExporter> GetCsvExporter()
        {
            var mockCsvExporter = new Mock<ICsvExporter>();
            mockCsvExporter.Setup(repo => repo.ExportEventsToCsv(It.IsAny<List<EventExportDto>>())).Returns(
                (List<EventExportDto> eventExportDtos) =>
                {
                    using var memoryStream = new MemoryStream();
                    using (var streamWriter = new StreamWriter(memoryStream))
                    {
                        using var csvWriter = new CsvWriter(streamWriter, new CultureInfo(""));
                        csvWriter.WriteRecords(eventExportDtos);
                    }

                    return memoryStream.ToArray();
                });
            return mockCsvExporter;
        }
    }
}
