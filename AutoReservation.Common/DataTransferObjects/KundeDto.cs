using AutoReservation.Common.DataTransferObjects.Core;
using System.Text;
using System;
using System.Runtime.Serialization;

namespace AutoReservation.Common.DataTransferObjects
{
    [DataContract]
    public class KundeDto : DtoBase<KundeDto>
    {
        private int id;
        private string nachname;
        private string vorname;
        private DateTime geburtsdatum;
        private DateTime rowversion;

        [DataMember]
        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged(nameof(Id));
                }

            }
        }

        [DataMember]
        public string Nachname
        {
            get
            {
                return nachname;
            }
            set
            {
                if (nachname != value)
                {
                    nachname = value;
                    OnPropertyChanged(nameof(Nachname));
                }
            }
        }

        [DataMember]
        public string Vorname
        {
            get
            {
                return vorname;
            }
            set
            {
                if (vorname != value)
                {
                    vorname = value;
                    OnPropertyChanged(nameof(Vorname));
                }
            }
        }

        [DataMember]
        public DateTime Geburtsdatum {
            get
            {
                return geburtsdatum;
            }
            set
            {
                if(geburtsdatum != value)
                {
                    geburtsdatum = value;
                    OnPropertyChanged(nameof(Geburtsdatum));
                }
            }
        }

        [DataMember]
        public DateTime RowVersion {
            get
            {
                return rowversion;
            }
            set
            {
                if(rowversion != value)
                {
                    rowversion = value;
                    OnPropertyChanged(nameof(RowVersion));
                }
            }
        }

        public override string Validate()
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(nachname))
            {
                error.AppendLine("- Nachname ist nicht gesetzt.");
            }
            if (string.IsNullOrEmpty(vorname))
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

        public override string ToString()
            => $"{Id}; {Nachname}; {Vorname}; {Geburtsdatum}";

    }
}
