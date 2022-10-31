using AppraisalTool.Application.Responses;
using AppraisalTool.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Users.Queries.GetMenuList
{
    public class GetMenuListQuery : IRequest<Response<List<MenuRoleMapping>>>
    {
        public int Id { get; set; }
    }
}
