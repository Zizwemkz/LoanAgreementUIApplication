using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VeriShareApplication.Models
{
    public class AgreementTypeViewModel
    {
        [Display(Name = "ID")]
        public int AgreementTypeId { get; set; }

        [Display(Name = "AgreementName")]
        [Required(ErrorMessage = "AgreementName is required")]
        public string AgreementName { get; set; }
    }
}