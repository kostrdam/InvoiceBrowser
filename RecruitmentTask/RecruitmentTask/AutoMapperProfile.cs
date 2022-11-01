using AutoMapper;
using RecruitmentTask.Data;
using RecruitmentTask.Dto;

namespace RecruitmentTask
{
    /// <summary>AutoMapper profiles configuration</summary>
    public class AutoMapperProfile : Profile
    {
        /// <summary>Constructor</summary>
        public AutoMapperProfile()
        {
            CreateMap<Invoice, InvoiceDto>();
            CreateMap<InvoiceDto, Invoice>();

            CreateMap<Item, ItemDto>();
            CreateMap<ItemDto, Item>();
        }
    }
}
