//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoReservation.Dal
{
    using System;
    using System.Collections.Generic;
    
    public abstract partial class Auto
    {
        public Auto()
        {
            this.Reservations = new HashSet<Reservation>();
        }
    
        public int Id { get; set; }
        public string Marke { get; set; }
        public int Tagestarif { get; set; }
    
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
