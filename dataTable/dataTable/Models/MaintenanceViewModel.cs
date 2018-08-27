using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dataTable
{
    public class MaintenanceViewModel
    {
        public int ID { get; set; }

        public string CategoryCode { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Required]
        [Display(Name = "Project Description")]
        public string ProjectDescription { get; set; }

        public string EmployeeName { get; set; }

        public string Description { get; set; }

        public string EmployeeEmailId { get; set; }

        public System.DateTime StartDate { get; set; }

        public System.DateTime EndDate { get; set; }

        public string Month { get; set; }

        [Required]
        [Display(Name = "Expected Start Date Of Project")]
        public System.DateTime ExpectedStartDateOfProject { get; set; }

        public System.DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public System.DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        [Required]
        [Display(Name = "Contact Name")]
        public string ContactName { get; set; }

        public string IsMobileDisplaySupported { get; set; }

        [Required]
        [Display(Name = "Contact Email")]
        [RegularExpression("^([a-zA-Z0-9-+.']+)@([a-zA-Z0-9-.]+).([a-zA-Z-.]{2,5})$", ErrorMessage = "Please enter a valid email id")]
        public string ContactEmail { get; set; }


        public string ContactPerson { get; set; }

        public string ContactMailId { get; set; }

        public string Document { get; set; }

        public string Frequency { get; set; }

        public string IsActive { get; set; }

    }
}