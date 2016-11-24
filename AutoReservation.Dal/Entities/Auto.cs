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
        [Key]
        [Column("Id"), Required]
        public int Id { get; set; }
        [Column("Marke"), Required, StringLength(20)]
        public string Marke { get; set; }
        [Column("Tagestarif"), Required]
        public int Tagestarif { get; set; }
        public int Basistarif { get; set; }
        [Column("AutoKlasse"), Required]
        public int AutoKlasse { get; set; }
        public virtual ICollection<Reservation> Reservationen { get; set; }
        [Column("RowVersion"), Required]
        public DateTime RowVersion { get; set; }
    } 
}
