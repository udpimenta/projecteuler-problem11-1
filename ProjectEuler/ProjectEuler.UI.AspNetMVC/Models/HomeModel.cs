using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjectEuler.UI.AspNetMVC.Models
{
    public class HomeModel
    {
        [Required]
        [Display(Name = "Input Grid")]
        public string InputGrid { get; set; }
    }
}