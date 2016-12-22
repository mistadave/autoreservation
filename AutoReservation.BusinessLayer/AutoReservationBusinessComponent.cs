using AutoReservation.Dal;
using AutoReservation.Dal.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace AutoReservation.BusinessLayer
{
    public class AutoReservationBusinessComponent
    {
        public List<Auto> Autos
        {
            get
            {
                using (AutoReservationContext context = new AutoReservationContext())
                {
                    return context.Autos.ToList();
                }
            }
        }

        public List<Kunde> Kunden
        {
            get
            {
                using(AutoReservationContext context = new AutoReservationContext())
                {
                    return context.Kunden.ToList();
                }
            }
        }

        public List<Reservation> Reservationen
        {
            get
            {
                using (AutoReservationContext context = new AutoReservationContext())
                {
                    return context.Reservationen.
                        Include(r => r.Auto).
                        Include(r => r.Kunde).
                        ToList();
                }
            }
        }

        public Auto GetAutoById(int id)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                Auto auto = context.Autos.SingleOrDefault(a => a.Id == id);
                if (auto == null) throw new EntityNotFoundException();
                return auto;
            }

        }

        public Kunde GetKundeById(int id)
        {
            using(AutoReservationContext context = new AutoReservationContext())
            {
                Kunde kunde = context.Kunden.SingleOrDefault(k => k.Id == id);
                if (kunde == null) throw new EntityNotFoundException();
                return kunde;
            }
         
        }

        public Reservation GetReservationById(int id)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                 Reservation reservation = context.Reservationen.
                    Include(r => r.Auto).
                    Include(r => r.Kunde).
                    SingleOrDefault(r => r.Id == id);
                if (reservation == null) throw new EntityNotFoundException();
                return reservation;
            }
        }

        public Auto InsertAuto(Auto auto)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                context.Autos.Add(auto);
                context.SaveChanges();
                return auto;
            }
        }

        public Kunde InsertKunde(Kunde kunde)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                context.Kunden.Add(kunde);
                context.SaveChanges();
                return kunde;
            }
        }

        public Reservation InsertReservation(Reservation reservation)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                context.Reservationen.Add(reservation);
                context.SaveChanges();
                return reservation;
            }
        }

        public void UpdateAuto(Auto auto)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                try
                {
                    context.Autos.Attach(auto);
                    context.Entry(auto).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    CreateLocalOptimisticConcurrencyException(context, auto);
                }
            }
        }

        public void UpdateKunde(Kunde kunde)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                try
                {
                    context.Kunden.Attach(kunde);
                    context.Entry(kunde).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    CreateLocalOptimisticConcurrencyException(context, kunde);
                }
            }
        }

        public void UpdateReservation(Reservation reservation)
        {
            if (reservation == null) return;
            using (AutoReservationContext context = new AutoReservationContext())
            {
                try
                {
                    context.Reservationen.Attach(reservation);
                    context.Entry(reservation).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    CreateLocalOptimisticConcurrencyException(context, reservation);
                }
            }
        }

        public void DeleteAuto(Auto auto)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                context.Autos.Attach(auto);
                context.Autos.Remove(auto);
                context.SaveChanges();
            }
        }

        public void DeleteKunde(Kunde kunde)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                context.Kunden.Attach(kunde);
                context.Kunden.Remove(kunde);
                context.SaveChanges();
            }
        }

        public void DeleteReservation(Reservation reservation)
        {
            using (AutoReservationContext context = new AutoReservationContext())
            {
                context.Reservationen.Attach(reservation);
                context.Reservationen.Remove(reservation);
                context.SaveChanges();
            }
        }

        private static LocalOptimisticConcurrencyException<T> CreateLocalOptimisticConcurrencyException<T>(AutoReservationContext context, T entity)
            where T : class
        {
            var dbEntity = (T)context.Entry(entity)
                .GetDatabaseValues()
                .ToObject();

            return new LocalOptimisticConcurrencyException<T>($"Update {typeof(Auto).Name}: Concurrency-Fehler", dbEntity);
        }
    }
}