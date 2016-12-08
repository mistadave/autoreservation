using AutoReservation.Common.DataTransferObjects;
using System.Collections.Generic;
using System.ServiceModel;

namespace AutoReservation.Common.Interfaces
{
    [ServiceContract]
    public interface IAutoReservationService
    {
        List<AutoDto> Autos
        {
            [OperationContract]
            get;
        }
        List<KundeDto> Kunden
        {
            [OperationContract]
            get;
        }
        List<ReservationDto> Reservationen
        {
            [OperationContract]
            get;
        }

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
        void UpdateAuto(AutoDto auto);

        [OperationContract]
        void UpdateKunde(KundeDto kunde);

        [OperationContract]
        void UpdateReservation(ReservationDto reservation);

        [OperationContract]
        void DeleteAuto(AutoDto auto);

        [OperationContract]
        void DeleteKunde(KundeDto kunde);

        [OperationContract]
        void DeleteReservation(ReservationDto reservation);
    }
}
