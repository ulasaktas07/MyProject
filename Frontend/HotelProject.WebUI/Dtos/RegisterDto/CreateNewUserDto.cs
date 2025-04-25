using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.RegisterDto
{
	public class CreateNewUserDto
	{
		[Required(ErrorMessage = "İsim Alanı Gereklidir.")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Soyisim Alanı Gereklidir.")]
		public string Surname { get; set; }
		[Required(ErrorMessage = "Kullanıcı Adı Alanı Gereklidir.")]
		[StringLength(20, ErrorMessage = "Kullanıcı Adı En Az 3 Karakter Olmalıdır.", MinimumLength = 3)]
		public string UserName { get; set; }
		[Required(ErrorMessage = "Email Alanı Gereklidir.")]
		[EmailAddress(ErrorMessage = "Geçerli Bir Email Adresi Giriniz.")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Şifre Alanı Gereklidir.")]
		[DataType(DataType.Password)]
		[StringLength(20, ErrorMessage = "Şifre En Az 6 Karakter Olmalıdır.", MinimumLength = 6)]
		public string Password { get; set; }
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Şifreler Eşleşmiyor.")]
		public string ConfirmPassword { get; set; }

	}
}
