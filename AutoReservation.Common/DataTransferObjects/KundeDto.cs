using System;
using System.Runtime.Serialization;
using System.Text;

namespace AutoReservation.Common.DataTransferObjects
{
    [DataContract]
    public class KundeDto : DtoBase
    {
        private int _id;
        [DataMember]
        public int Id
        {
            get { return _id; }
            set
            {
                if(_id == value)return;
                _id = value;
                RaisePropertyChanged();
            }
        }
        private string _nachname;
        [DataMember]
        public string Nachname
        {
            get { return _nachname; }
            set
            {
                if(_nachname == value) return;
                _nachname = value;
                RaisePropertyChanged();
            }
        }
        [DataMember]
        private string _vorname;
        public string Vorname
        {
            get { return _vorname; }
            set
            {
                if (_vorname == value) return;
                _vorname = value;
                RaisePropertyChanged();
            }
        }
        [DataMember]
        private DateTime _geburtsTag;
        public System.DateTime Geburtsdatum
        {
            get { return _geburtsTag; }
            set
            {
                if (_geburtsTag == value) return;
                _geburtsTag = value;
                RaisePropertyChanged();
            }
        }

        public override string Validate()
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(Nachname))
            {
                error.AppendLine("- Nachname ist nicht gesetzt.");
            }
            if (string.IsNullOrEmpty(Vorname))
            {
                error.AppendLine("- Vorname ist nicht gesetzt.");
            }
            if (Geburtsdatum == DateTime.MinValue)
            {
                error.AppendLine("- Geburtsdatum ist nicht gesetzt.");
            }

            if (error.Length == 0) { return null; }

            return error.ToString();
        }

        public override object Clone()
        {
            return new KundeDto
            {
                Id = Id,
                Nachname = Nachname,
                Vorname = Vorname,
                Geburtsdatum = Geburtsdatum
            };
        }

        public override string ToString()
        {
            return string.Format(
                "{0}; {1}; {2}; {3}",
                Id,
                Nachname,
                Vorname,
                Geburtsdatum);
        }

    }
}
