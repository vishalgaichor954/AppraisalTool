using AppraisalTool.Application.Features.Events.Queries.GetEventsExport;
using System.Collections.Generic;

namespace AppraisalTool.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos);
    }
}
