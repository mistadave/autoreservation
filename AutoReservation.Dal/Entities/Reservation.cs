using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoReservation.Dal.Entities
{
    [Table("Reservation")]
    public class Reservation
    {
        [Key]
        [Column("Id"), Required]
        public int ReservationsNr { get; set; }
        [ForeignKey("AutoId"), Required]
        public int AutoId { get; set; }
        [ForeignKey("Auto"), Required]
        public virtual Auto Auto { get; set; }
        [ForeignKey("KundeId"), Required]
        public int KundeId { get; set; }
        [ForeignKey("Kunde"), Required]
        public virtual Kunde Kunde { get; set; }
        [Column("Von"), Required]
        public DateTime Von { get; set; }
        [Column("Bis"), Required]
        public DateTime Bis { get; set; }
        [Column("RowVersion"), Required]
        public DateTime RowVersion { get; set; }
    }
}
