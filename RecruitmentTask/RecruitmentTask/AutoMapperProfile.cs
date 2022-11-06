using AutoMapper;
using RecruitmentTask.Data.Model;
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
            CreateMap<InvoiceDto, Invoice>()
                .ForMember(i => i.Id, opt => opt.Ignore());

            CreateMap<InvoiceItem, InvoiceItemDto>()
                .ForMember(i => i.Id, opt => opt.MapFrom(i => i.Item.Id))
                .ForMember(i => i.Name, opt => opt.MapFrom(i => i.Item.Name))
                .ForMember(i => i.Price, opt => opt.MapFrom(i => i.Item.Price))
                .ForMember(i => i.Quantity, opt => opt.MapFrom(i => i.Quantity));
            CreateMap<InvoiceItemDto, InvoiceItem>()
                .ForMember(i => i.Id, opt => opt.Ignore())
                .ForMember(i => i.ItemId, opt => opt.MapFrom(i => i.Id))
                .ForMember(i => i.Quantity, opt => opt.MapFrom(i => i.Quantity));


            CreateMap<Item, ItemDto>();
            CreateMap<ItemDto, Item>();
        }
    }
}
