using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoReservation.Dal.Entities
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public int AutoId { get; set; }
        public int KundeId { get; set; }
        public DateTime Von { get; set; }
        public DateTime Bis { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

        [ForeignKey("AutoId")]
        public virtual Auto Auto { get; set; }
        [ForeignKey("KundeId")]
        public virtual Kunde Kunde { get; set; }
    }
}
