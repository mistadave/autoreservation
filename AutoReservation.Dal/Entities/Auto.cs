using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace AutoReservation.Dal.Entities
{
    [Table("Auto")]
    public abstract class Auto
    {

        public Auto()
        {
            this.Reservationen = new HashSet<Reservation>();
        }
        
        public int Id { get; set; }
        public string Marke { get; set; }
        public int Tagestarif { get; set; }
       
        public int AutoKlasse { get; set; }

        public virtual ICollection<Reservation> Reservationen { get; set; }
        public DateTime RowVersion { get; set; }
    }
}
