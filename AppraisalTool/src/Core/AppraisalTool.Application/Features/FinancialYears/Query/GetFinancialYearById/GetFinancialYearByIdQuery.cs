﻿using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.FinancialYears.Query.GetFinancialYearById
{
    public class GetFinancialYearByIdQuery:IRequest<Response<GetFinancialYearByIdDto>>
    {
        public GetFinancialYearByIdQuery()
        {

        }
        public GetFinancialYearByIdQuery(int id)
        {
            Id = id;
            
        }
        public int Id { get; set; }
    }
}
