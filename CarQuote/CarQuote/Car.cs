//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarQuote
{
    using System;
    using System.Collections.Generic;
    
    public partial class Car
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public Nullable<int> Caryear { get; set; }
        public string Carmake { get; set; }
        public string Carmodel { get; set; }
        public Nullable<bool> DUI { get; set; }
        public Nullable<int> NumberofspeedingTickets { get; set; }
        public string CoverageType { get; set; }
        public Nullable<int> Total { get; set; }
    }
}