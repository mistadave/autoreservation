using System;
using System.Collections.Generic;
using System.Diagnostics;
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using AutoReservation.BusinessLayer;

namespace AutoReservation.Service.Wcf
{
    public class AutoReservationService : IAutoReservationService
    {
        private AutoReservationBusinessComponent businessComponent;
        public AutoReservationService()
        {
            businessComponent = new AutoReservationBusinessComponent();
        }
        public List<AutoDto> Autos
        {
            get
            {
                WriteActualMethod();
                return businessComponent.Autos.ConvertToDtos();

            }
        }

        public List<KundeDto> Kunden
        {
            get
            {
                WriteActualMethod();
                return businessComponent.Kunden.ConvertToDtos();
            }
        }

        public List<ReservationDto> Reservationen
        {
            get
            {
                WriteActualMethod();
                return businessComponent.Reservationen.ConvertToDtos();
            }
        }

        private static void WriteActualMethod()
        {
            Console.WriteLine($"Calling: {new StackTrace().GetFrame(1).GetMethod().Name}");
        }

        public void DeleteAuto(AutoDto auto)
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }

        public void DeleteKunde(KundeDto kunde)
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }

        public void DeleteReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }

        public AutoDto GetAutoById(int id)
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }

        public KundeDto GetKundeById(int id)
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }

        public ReservationDto GetReservationByNr(int reservationsNr)
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }

        public AutoDto InsertAuto(AutoDto auto)
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }

        public KundeDto InsertKunde(KundeDto kunde)
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }

        public ReservationDto InsertReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }

        public void UpdateAuto(AutoDto auto)
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }

        public void UpdateKunde(KundeDto kunde)
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }

        public void UpdateReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            businessComponent.UpdateReservation(reservation.ConvertToEntity());
        }
    }
}