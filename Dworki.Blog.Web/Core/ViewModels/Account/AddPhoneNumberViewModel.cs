﻿using System.ComponentModel.DataAnnotations;

namespace Dworki.Blog.Web.Core.ViewModels.Account
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }
}