using System;
using System.Runtime.Serialization;
using System.Text;

namespace AutoReservation.Common.DataTransferObjects
{
    [DataContract]
    public class ReservationDto : DtoBase
    {
        private DateTime _von;
        private DateTime _bis;

        [DataMember]
        public System.DateTime Von
        {
            get { return _von; }
            set
            {
                if (_von == value) return;
                RaisePropertyChanged();
                _von = value;
            }
        }
        [DataMember]
        public System.DateTime Bis
        {
            get { return _bis; }
            set
            {
                if (_bis == value) return;
                RaisePropertyChanged();
                _bis = value;
            }
        }

        private AutoDto _auto;
        [DataMember]
        public AutoDto Auto
        {
            get { return _auto; }
            set
            {
                if(_auto == value) return;
                _auto = value;
                RaisePropertyChanged();
            }
        }

        private KundeDto _kunde;
        [DataMember]
        public KundeDto Kunde
        {
            get { return _kunde; }
            set
            {
                if(_kunde == value) return;
                _kunde = value;
                RaisePropertyChanged();
            }
        }

        private int _reservationNr;
        [DataMember]
        public int ReservationNr
        {
            get { return _reservationNr; }
            set
            {
                if(_reservationNr == value) return;
                _reservationNr = value;
                RaisePropertyChanged();
            }
        }

        public override string Validate()
        {
            StringBuilder error = new StringBuilder();
            if (Von == DateTime.MinValue)
            {
                error.AppendLine("- Von-Datum ist nicht gesetzt.");
            }
            if (Bis == DateTime.MinValue)
            {
                error.AppendLine("- Bis-Datum ist nicht gesetzt.");
            }
            if (Von > Bis)
            {
                error.AppendLine("- Von-Datum ist grösser als Bis-Datum.");
            }
            if (Auto == null)
            {
                error.AppendLine("- Auto ist nicht zugewiesen.");
            }
            else
            {
                string autoError = Auto.Validate();
                if (!string.IsNullOrEmpty(autoError))
                {
                    error.AppendLine(autoError);
                }
            }
            if (Kunde == null)
            {
                error.AppendLine("- Kunde ist nicht zugewiesen.");
            }
            else
            {
                string kundeError = Kunde.Validate();
                if (!string.IsNullOrEmpty(kundeError))
                {
                    error.AppendLine(kundeError);
                }
            }


            if (error.Length == 0) { return null; }

            return error.ToString();
        }

        public override object Clone()
        {
            return new ReservationDto
            {
                ReservationNr = ReservationNr,
                Von = Von,
                Bis = Bis,
                Auto = (AutoDto)Auto.Clone(),
                Kunde = (KundeDto)Kunde.Clone()
            };
        }

        public override string ToString()
        {
            return string.Format(
                "{0}; {1}; {2}; {3}; {4}",
                ReservationNr,
                Von,
                Bis,
                Auto,
                Kunde);
        }

    }
}
