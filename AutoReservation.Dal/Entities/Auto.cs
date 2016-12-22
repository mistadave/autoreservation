using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace AutoReservation.Dal.Entities
{
    public abstract class Auto
    {
        public Auto()
        {
            this.Reservationen = new HashSet<Reservation>();
        }
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string Marke { get; set; }
        public int Tagestarif { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual ICollection<Reservation> Reservationen { get; set; }
       
    }
}
