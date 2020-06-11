using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.ViewModels
{
    public class RegisterModel
    {
		[Required]
		//[DataType(DataType.EmailAddress)]
		[DisplayName("شناسه")]
		public string Username { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[DisplayName("پسورد")]
		public string Password { get; set; }

		[Required]
		[DisplayName("کشور")]
		public string Country { get; set; }
	}
}