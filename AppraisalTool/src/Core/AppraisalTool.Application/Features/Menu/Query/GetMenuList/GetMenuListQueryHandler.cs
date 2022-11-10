using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Response;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Menu.Query.GetMenuList
{
    public class GetMenuListQueryHandler : IRequestHandler<GetMenuListQuery, Response<IEnumerable<GetMenuListQueryVm>>>
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IMapper _mapper;

        public GetMenuListQueryHandler(IMenuRepository menuRepository, IMapper mapper)
        {
            _menuRepository = menuRepository;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<GetMenuListQueryVm>>> Handle(GetMenuListQuery request, CancellationToken cancellationToken)
        {
            //var allmenu = await _menuRepository.GetAllMenuList();
            //if (allmenu != null)
            //{
            //    var dataVM = _mapper.Map<IEnumerable<GetMenuListQueryVm>>(allmenu);
            //    return new Response<IEnumerable<GetMenuListQueryVm>>(dataVM, "success");
            //}
            //return new Response<IEnumerable<GetMenuListQueryVm>>(null, "Failed");
            var menuresponse = await _menuRepository.GetAllMenuList();
            if(menuresponse != null)
            {
                return new Response<IEnumerable<GetMenuListQueryVm>>(menuresponse, "Success");
            }
            else
            {
                return new Response<IEnumerable<GetMenuListQueryVm>>(null, "Failed");
            }
        }
    }
}
