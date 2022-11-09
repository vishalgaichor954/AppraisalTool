﻿using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Menu.Query.GetMenuList
{
    public class GetMenuListQuery:IRequest<Response<IEnumerable<GetMenuListQueryVm>>>
    {
    }
}
