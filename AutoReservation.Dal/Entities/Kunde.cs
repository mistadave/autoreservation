using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace AutoReservation.Dal.Entities
{
    [Table("Kunde")]
  public class Kunde
    {
        [Key]
        [Column("Id"), Required]
        public int Id { get; set; }
        [Column("Nachname"), Required, StringLength(20)]
        public string Nachname { get; set; }
        [Column("Vorname"), Required, StringLength(20)]
        public string Vorname { get; set; }
        [Column("Geburtsdatum"), Required]
        public DateTime Geburtsdatum { get; set; }
        public virtual ICollection<Reservation> Reservationen { get; set; }
        [Column("RowVersion"), Required]
        public DateTime RowVersion { get; set; }
    }
}
