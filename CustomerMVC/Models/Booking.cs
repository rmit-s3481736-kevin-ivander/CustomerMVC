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
    
    public partial class Booking
    {
        public int Booking_ID { get; set; }
        public string Movie_Title { get; set; }
        public string Movie_Time { get; set; }
        public string Session_Time { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> Ticket { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Poster { get; set; }
    }
}
