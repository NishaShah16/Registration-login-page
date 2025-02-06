using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NDProject.Models
{
    public class Category
    {
        public List<string> Categories { get; set; }
        public int Id { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public string Category_name { get; set; }
    }
    public class Subcategory
    {
        public List<string> Subcategories { get; set; }
        public int Id { get; set; }
        [Required(ErrorMessage = "Category is required.")]
        public string Subcategory_name { get; set; }

    }
    public class CollegeName
    {
        public List<string> Colleges { get; set; }
        public int Id { get; set; }
        [Required(ErrorMessage = "College Name is required.")]
        public string College_Name { get; set; }

    }
    public class Registration
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required(ErrorMessage = "Uttarakhand Domicile is required.")]
        [Display(Name = "Do You Have Uttarakhand Domicile?")]
        public string Domicile { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Certificate No. is required.")]
        [Display(Name = "Certificate No. 1")]
        public string CertNo1 { get; set; }

        [Required(ErrorMessage = "Issue Date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Issue Date 1")]
        public DateTime IssueDate1 { get; set; }


        [Required(ErrorMessage = "Sub Category is required.")]
        public string SubCategory { get; set; }

        [Required(ErrorMessage = "Certificate No. 2 is required.")]
        [Display(Name = "Certificate No. 2")]
        public string CertNo2 { get; set; }

        [Required(ErrorMessage = "Internship Certificate is required.")]
        [Display(Name = "Do You Have Internship Certificate?")]
        public string InternCert { get; set; }

        [Required(ErrorMessage = "Completion Date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Completion")]
        public DateTime CompletionDate { get; set; }

        [Required(ErrorMessage = "Completion Certificate Issuer is required.")]
        [Display(Name = "Completion Certificate Issued By")]
        public string Issuer { get; set; }

        [Required(ErrorMessage = "Name of Council is required.")]
        public string Council { get; set; }

        [Required(ErrorMessage = "Registration No. is required.")]
        [Display(Name = "Registration No.")]
        public string RegNo { get; set; }

        [Required(ErrorMessage = "Bonded Candidate status is required.")]
        [Display(Name = "Are You a Bonded Candidate?")]
        public string Bonded { get; set; }

        [Display(Name = "Upload NOC")]
      //  public string NOCFilePath { get; set; } // For storing the file path in the database
        //[DataType(DataType.Upload)]
        public HttpPostedFileBase NOCFilePath { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Issue of NOC")]
        public DateTime? NOCIssueDate { get; set; } // Nullable if not always required

        [Required(ErrorMessage = "Remote Area Benefit is required.")]
        [Display(Name = "Are you claiming the service benefit of Remote Area?")]
        public string RemoteBenefit { get; set; }

        [Required(ErrorMessage = "Number of Years is required.")]
        [Display(Name = "No. of Years")]
        public string Years { get; set; }

        [Required(ErrorMessage = "M.B.B.S Pass Out State is required.")]
        [Display(Name = "M.B.B.S Pass Out State")]
        public string MBBSState { get; set; }

        [Required(ErrorMessage = "College Name is required.")]
        [Display(Name = "College Name")]
        public string College { get; set; }

        [Required(ErrorMessage = "Quota Seats are required.")]
        [Display(Name = "You Are Eligible For Both State & All India Quota Seats")]
        public string QuotaSeats { get; set; }

        [Required(ErrorMessage = "Eligibility for Private College is required.")]
        [Display(Name = "You Are Eligible Only For All India Quota Seat in Pvt Medical College")]

        public string EligiblePrivateOnly { get; set; }
        [Required(ErrorMessage = "Issue Date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Issue Date 2")]
        public DateTime IssueDate2 { get; set; }
        [Required(ErrorMessage = "Are You a Regular UK State PMHS Candidate?:")]
        [Display(Name = "Are You a Regular UK State PMHS Candidate?:")]

        public string PMHSCandidate { get; set; }
    }
   
}