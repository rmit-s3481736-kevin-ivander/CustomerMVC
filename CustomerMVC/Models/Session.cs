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
    
    public partial class Session
    {
        public int Session_ID { get; set; }
        public int Movie_ID { get; set; }
        public string Movie_Title { get; set; }
        public int CineplexID { get; set; }
        public string Location { get; set; }
        public string Session_Time { get; set; }
        public string Session_Day { get; set; }
    
        public virtual Movies Movy { get; set; }
    }
}