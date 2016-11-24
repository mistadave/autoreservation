﻿using AutoReservation.Common.DataTransferObjects;
using System.Collections.Generic;
using System.ServiceModel;

namespace AutoReservation.Common.Interfaces
{
    [ServiceContract]
    public interface IAutoReservationService
    {
        //List<AutoDto> Autos();
        //List<KundeDto> Kunden();
        //List<ReservationDto> Reservationen();

        [OperationContract]
        AutoDto GetAutoById(int id);

        [OperationContract]
        KundeDto GetKundeById(int id);

        [OperationContract]
        ReservationDto GetReservationByNr(int reservationsNr);

        [OperationContract]
        AutoDto InsertAuto(AutoDto auto);

        [OperationContract]
        KundeDto InsertKunde(KundeDto kunde);

        [OperationContract]
        ReservationDto InsertReservation(ReservationDto reservation);

        [OperationContract]
        AutoDto UpdateAuto(AutoDto auto);

        [OperationContract]
        KundeDto UpdateKunde(KundeDto kunde);

        [OperationContract]
        ReservationDto UpdateReservation(ReservationDto reservation);

        [OperationContract]
        void DeleteAuto(AutoDto auto);

        [OperationContract]
        void DeleteKunde(KundeDto kunde);

        [OperationContract]
        void DeleteReservation(ReservationDto reservation);
    }
}
