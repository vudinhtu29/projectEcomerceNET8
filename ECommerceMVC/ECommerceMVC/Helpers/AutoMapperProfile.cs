using AutoMapper;
using ECommerceMVC.Data;
using ECommerceMVC.ViewModels;

namespace ECommerceMVC.Helpers
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile() {
			//map 1 chieu
			CreateMap<RegisterVM, KhachHang>();
				//.ForMember(kh => kh.HoTen, option => option.MapFrom(RegisterVM =>
				//RegisterVM.HoTen))
				//.ReverseMap();//map 2 chieu
		}
	}
}
