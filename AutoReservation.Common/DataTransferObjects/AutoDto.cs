using System;
using System.Runtime.Serialization;
using System.Text;

namespace AutoReservation.Common.DataTransferObjects
{
    [DataContract]
    [KnownType(typeof(AutoKlasse))]
    public class AutoDto : DtoBase
    {
        private AutoKlasse _autoKlasse;
        [DataMember]
        public AutoKlasse AutoKlasse
        {
            get { return _autoKlasse; }
            set
            {
                if (_autoKlasse == value) return;
                _autoKlasse = value;
                RaisePropertyChanged();
            }

        }

        private int _id;
        [DataMember]
        public int Id
        {
            get { return _id; }
            set
            {
                if(_id == value) return;
                _id = value;
                RaisePropertyChanged();
            }
        }
        private string _marke;
        [DataMember]
        public string Marke
        {
            get { return _marke; }
            set
            {
                if(_marke == value) return;
                _marke = value;
                RaisePropertyChanged();
            }
        }
        private int _tagesTarif;
        [DataMember]
        public int Tagestarif
        {
            get { return _tagesTarif; }
            set
            {
                if(_tagesTarif == value) return;
                _tagesTarif = value;
                RaisePropertyChanged();
            }
        }

        private int _basisTarif;
        [DataMember]
        public int Basistarif
        {
            get { return _basisTarif; }
            set
            {
                if (_basisTarif == value) return;
                _basisTarif = value;
                RaisePropertyChanged();
            }
        }

        public override string Validate()
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(Marke))
            {
                error.AppendLine("- Marke ist nicht gesetzt.");
            }
            if (Tagestarif <= 0)
            {
                error.AppendLine("- Tagestarif muss grösser als 0 sein.");
            }
            if (AutoKlasse == AutoKlasse.Luxusklasse && Basistarif <= 0)
            {
                error.AppendLine("- Basistarif eines Luxusautos muss grösser als 0 sein.");
            }

            if (error.Length == 0) { return null; }

            return error.ToString();
        }

        public override object Clone()
        {
            return new AutoDto
            {
                Id = Id,
                Marke = Marke,
                Tagestarif = Tagestarif,
                AutoKlasse = AutoKlasse,
                Basistarif = Basistarif
            };
        }

        public override string ToString()
        {
            return string.Format(
                "{0}; {1}; {2}; {3}; {4}",
                Id,
                Marke,
                Tagestarif,
                Basistarif,
                AutoKlasse);
        }

    }
}
