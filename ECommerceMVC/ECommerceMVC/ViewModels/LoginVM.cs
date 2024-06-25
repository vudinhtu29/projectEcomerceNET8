using System.ComponentModel.DataAnnotations;

namespace ECommerceMVC.ViewModels
{
	public class LoginVM
	{
		[Display(Name = "Ten dang nhap")]
		[Required(ErrorMessage ="Chua nhap ten dang nhap")]
		[MaxLength(20,ErrorMessage ="Toi da 20 ki tu")]
		public string UserName { get; set; }

		[Display(Name = "Mat Khau")]
		[Required(ErrorMessage = "Chua nhap mat khau")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

	}
}
