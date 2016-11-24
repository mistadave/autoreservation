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
        public int Id { get; set; }
        [ForeignKey("AutoId"), Required]
        public virtual Auto AutoId { get; set; }
        [ForeignKey("KundeId"), Required]
        public virtual Kunde KundenId { get; set; }
        [Column("Von"), Required]
        public DateTime Von { get; set; }
        [Column("Bis"), Required]
        public DateTime Bis { get; set; }
        [Column("RowVersion"), Required]
        public DateTime RowVersion { get; set; }
    }
}
