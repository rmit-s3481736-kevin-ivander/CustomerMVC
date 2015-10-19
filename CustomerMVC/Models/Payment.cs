//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CustomerMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Payment
    {
         [Required]
        public string First_Name { get; set; }
         [Required]
        public string Last_Name { get; set; }
         [Required]
        public string CardNo { get; set; }
         [Required]
         [StringLength(3)]
        public string CCV { get; set; }
         [Required]
        public string CardType { get; set; }
         [Required]
        public Nullable<System.DateTime> ExpiredDate { get; set; }
    }
}
