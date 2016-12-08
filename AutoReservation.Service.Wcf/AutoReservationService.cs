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
            businessComponent.DeleteAuto(auto.ConvertToEntity());
        }

        public void DeleteKunde(KundeDto kunde)
        {
            WriteActualMethod();
            businessComponent.DeleteKunde(kunde.ConvertToEntity());
        }

        public void DeleteReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            businessComponent.DeleteReservation(reservation.ConvertToEntity());
        }

        public AutoDto GetAutoById(int id)
        {
            WriteActualMethod();
            return businessComponent.GetAutoById(id).ConvertToDto();
        }

        public KundeDto GetKundeById(int id)
        {
            WriteActualMethod();
            return businessComponent.GetKundeById(id).ConvertToDto();
        }

        public ReservationDto GetReservationByNr(int reservationsNr)
        {
            WriteActualMethod();
            return businessComponent.GetReservationById(reservationsNr).ConvertToDto();
        }

        public AutoDto InsertAuto(AutoDto auto)
        {
            WriteActualMethod();
            return businessComponent.InsertAuto(auto.ConvertToEntity()).ConvertToDto();
        }

        public KundeDto InsertKunde(KundeDto kunde)
        {
            WriteActualMethod();
            return businessComponent.InsertKunde(kunde.ConvertToEntity()).ConvertToDto();
        }

        public ReservationDto InsertReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            return businessComponent.InsertReservation(reservation.ConvertToEntity()).ConvertToDto();
            
        }

        public void UpdateAuto(AutoDto auto)
        {
            WriteActualMethod();
            businessComponent.UpdateAuto(auto.ConvertToEntity());
        }

        public void UpdateKunde(KundeDto kunde)
        {
            WriteActualMethod();
            businessComponent.UpdateKunde(kunde.ConvertToEntity());
        }

        public void UpdateReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            businessComponent.UpdateReservation(reservation.ConvertToEntity());
        }
    }
}