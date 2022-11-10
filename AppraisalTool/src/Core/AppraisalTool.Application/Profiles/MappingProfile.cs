using AutoMapper;
using AppraisalTool.Application.Features.Categories.Commands.CreateCategory;
using AppraisalTool.Application.Features.Categories.Commands.StoredProcedure;
using AppraisalTool.Application.Features.Categories.Queries.GetCategoriesList;
using AppraisalTool.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using AppraisalTool.Application.Features.Events.Commands.CreateEvent;
using AppraisalTool.Application.Features.Events.Commands.Transaction;
using AppraisalTool.Application.Features.Events.Commands.UpdateEvent;
using AppraisalTool.Application.Features.Events.Queries.GetEventDetail;
using AppraisalTool.Application.Features.Events.Queries.GetEventsExport;
using AppraisalTool.Application.Features.Events.Queries.GetEventsList;
using AppraisalTool.Application.Features.Orders.GetOrdersForMonth;
using AppraisalTool.Domain.Entities;
using AppraisalTool.Application.Models.AppraisalTool;
using AppraisalTool.Application.Features.SelfAppraisal.Queries.GetData;
using AppraisalTool.Application.Features.Users.Command.CreateUserCommand;
using AppraisalTool.Application.Features.Users.Command.UpdateUserCommand;
using AppraisalTool.Application.Features.Users.Query.GetUserById;
using AppraisalTool.Application.Features.SelfAppraisal.Queries.GetYear;
using AppraisalTool.Application.Features.Users.Query.GetUserList;
using AppraisalTool.Application.Features.AppraisalResults.Commands.AddAppraisalResult;
using AppraisalTool.Application.Features.Menu.Command.CreateMenuCommand;
using AppraisalTool.Application.Features.SelfAppraisal.Command.AddAppraisal;

namespace AppraisalTool.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, TransactionCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();
            CreateMap<Event, EventExportDto>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<Category, StoredProcedureCommand>();
            CreateMap<Category, StoredProcedureDto>();

            CreateMap<Order, OrdersForMonthDto>();

            CreateMap<Event, EventListVm>().ConvertUsing<EventVmCustomMapper>();

            //Appraisal Tool
            CreateMap<User, CreateUserCommand>().ReverseMap();
            //CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, AddUserViewModel>().ReverseMap();
            //CreateMap<Appraisal, GetDataVM>().ConvertUsing<GetDataVmCustomMapper>();
            //CreateMap<Appraisal, GetDataQuery>().ReverseMap();  
            CreateMap<User, GetDataVM>().ConvertUsing<GetDataVmCustomMapper>();
            


            CreateMap<Appraisal, GetYearQuery>().ReverseMap();
            CreateMap<Appraisal, AddAppraisalVM>().ReverseMap();
            CreateMap<FinancialYear, GetYearVm>().ReverseMap();


            CreateMap<User, UpdateUserCommand>().ReverseMap();

            CreateMap<User, GetUserByIdDto>().ReverseMap();

            CreateMap<User, GetUserListQueryVm>().ConvertUsing<GetUserListVmCustomMapper>();

            CreateMap<AppraisalResult, AddAppraisalResultDto>().ReverseMap();

            CreateMap<MenuList, CreateMenuCommand>().ReverseMap();
        }
    }
}
