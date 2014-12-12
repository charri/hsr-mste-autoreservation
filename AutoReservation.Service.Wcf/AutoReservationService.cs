using System.Runtime.Serialization;
using System.ServiceModel;
using AutoReservation.BusinessLayer;
using AutoReservation.Common.Exceptions;
using AutoReservation.Common.Interfaces;
using System;
using System.Diagnostics;
using AutoReservation.Dal;

namespace AutoReservation.Service.Wcf
{
    public class AutoReservationService
        : IAutoReservationService
    {

        private static void WriteActualMethod()
        {
            Console.WriteLine("Calling: " + new StackTrace().GetFrame(1).GetMethod().Name);
        }

        public System.Collections.Generic.IEnumerable<Common.DataTransferObjects.AutoDto> Autos
        {
            get
            {
                WriteActualMethod();
                return AutoReservationBusinessComponent.FindAll<Auto>().ConvertToDtos();
            }
        }

        public System.Collections.Generic.List<Common.DataTransferObjects.AutoDto> FindAllAutos()
        {
            WriteActualMethod();
            return AutoReservationBusinessComponent.FindAll<Auto>().ConvertToDtos();
        }

        public Common.DataTransferObjects.AutoDto FindAuto(int id)
        {
            WriteActualMethod();
            var result = AutoReservationBusinessComponent.Find<Auto>(id).ConvertToDto();

            if(result == null) throw new FaultException<NotFoundException>(new NotFoundException());
            return result;
        }

        public Common.DataTransferObjects.AutoDto InsertAuto(Common.DataTransferObjects.AutoDto auto)
        {
            WriteActualMethod();
            return AutoReservationBusinessComponent.Insert(auto.ConvertToEntity()).ConvertToDto();
        }

        public Common.DataTransferObjects.AutoDto UpdateAuto(Common.DataTransferObjects.AutoDto original, Common.DataTransferObjects.AutoDto modified)
        {
            WriteActualMethod();
            return AutoReservationBusinessComponent.Update(original.ConvertToEntity(), modified.ConvertToEntity()).ConvertToDto();
        }

        public Common.DataTransferObjects.AutoDto DeleteAuto(Common.DataTransferObjects.AutoDto auto)
        {
            WriteActualMethod();
            return AutoReservationBusinessComponent.DeleteAuto(auto.ConvertToEntity()).ConvertToDto();
        }

        public System.Collections.Generic.IEnumerable<Common.DataTransferObjects.KundeDto> Kunden
        {
            get
            {
                WriteActualMethod();
                return AutoReservationBusinessComponent.FindAll<Kunde>().ConvertToDtos();
            }
        }

        public System.Collections.Generic.List<Common.DataTransferObjects.KundeDto> FindAllKunden()
        {
            WriteActualMethod();
            return AutoReservationBusinessComponent.FindAll<Kunde>().ConvertToDtos();
        }

        public Common.DataTransferObjects.KundeDto FindKunde(int id)
        {
            WriteActualMethod();
            var result = AutoReservationBusinessComponent.Find<Kunde>(id).ConvertToDto();

            if (result == null) throw new FaultException<NotFoundException>(new NotFoundException());
            return result;
        }

        public Common.DataTransferObjects.KundeDto InsertKunde(Common.DataTransferObjects.KundeDto kunde)
        {
            WriteActualMethod();
            return AutoReservationBusinessComponent.Insert(kunde.ConvertToEntity()).ConvertToDto();
        }

        public Common.DataTransferObjects.KundeDto UpdateKunde(Common.DataTransferObjects.KundeDto original, Common.DataTransferObjects.KundeDto modified)
        {
            WriteActualMethod();
            return AutoReservationBusinessComponent.Update(original.ConvertToEntity(), modified.ConvertToEntity()).ConvertToDto();
        }

        public Common.DataTransferObjects.KundeDto DeleteKunde(Common.DataTransferObjects.KundeDto kunde)
        {
            WriteActualMethod();
            return AutoReservationBusinessComponent.DeleteKunde(kunde.ConvertToEntity()).ConvertToDto();
        }

        public System.Collections.Generic.IEnumerable<Common.DataTransferObjects.ReservationDto> Reservationen
        {
            get
            {
                WriteActualMethod();
                return AutoReservationBusinessComponent.FindAllReservationen().ConvertToDtos();
            }
        }

        public System.Collections.Generic.List<Common.DataTransferObjects.ReservationDto> FindAllReservationen()
        {
            WriteActualMethod();
            return AutoReservationBusinessComponent.FindAllReservationen().ConvertToDtos();
        }

        public Common.DataTransferObjects.ReservationDto FindReservation(int id)
        {
            WriteActualMethod();
            var result = AutoReservationBusinessComponent.FindReservation(id).ConvertToDto();
            if (result == null) throw new FaultException<NotFoundException>(new NotFoundException());
            return result;
        }

        public Common.DataTransferObjects.ReservationDto InsertReservation(Common.DataTransferObjects.ReservationDto reservation)
        {
            WriteActualMethod();
            return AutoReservationBusinessComponent.Insert(reservation.ConvertToEntity()).ConvertToDto();
        }

        public Common.DataTransferObjects.ReservationDto UpdateReservation(Common.DataTransferObjects.ReservationDto original, Common.DataTransferObjects.ReservationDto modified)
        {
            WriteActualMethod();
            return AutoReservationBusinessComponent.Update(original.ConvertToEntity(), modified.ConvertToEntity()).ConvertToDto();
        }

        public Common.DataTransferObjects.ReservationDto DeleteReservation(Common.DataTransferObjects.ReservationDto reservation)
        {
            WriteActualMethod();
            return AutoReservationBusinessComponent.Delete(reservation.ConvertToEntity()).ConvertToDto();
        }
    }
}