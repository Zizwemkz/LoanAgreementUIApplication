using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VeriShareApplication.Models
{
    public class CustomerLoanViewModel
    {
        
        [Required]
        [Display(Name = "CustomerId")]
        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "AgreementTypeId")]
        public int AgreementId { get; set; }

        public float Amount { get; set; }
        public float ReturnInterest { get; set; }
        public double RepoRate { get; set; }

        public int StatusCode { get; set; }
        public string TransectionMessage { get; set; }
        public string Agreementpicked { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}