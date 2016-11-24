﻿using AutoReservation.Common.DataTransferObjects.Core;
using System.Text;
using System;

namespace AutoReservation.Common.DataTransferObjects
{
    public class ReservationDto : DtoBase<ReservationDto>
    {
        private int reservationsnr;
        private DateTime von;
        private DateTime bis;
        private AutoDto auto;
        private KundeDto kunde;
        private DateTime rowversion;

        public int ReservationsNr
        {
            get
            {
                return reservationsnr;
            }
            set
            {
                if(reservationsnr != value)
                {
                    reservationsnr = value;
                    OnPropertyChanged(nameof(ReservationsNr));
                }
            }
        }

        public DateTime Von
        {
            get
            {
                return von;
            }
            set
            {
                if(von != value)
                {
                    von = value;
                    OnPropertyChanged(nameof(Von));
                }
            }
        }

        public DateTime Bis
        {
            get
            {
                return bis;
            }
            set
            {
                if (bis != value)
                {
                    bis = value;
                    OnPropertyChanged(nameof(Bis));
                }
            }
        }
        public AutoDto Auto
        {
            get
            {
                return auto;
            }
            set
            {
                if (auto != value)
                {
                    auto = value;
                    OnPropertyChanged(nameof(Auto));
                }
            }
        }
        public KundeDto Kunde
        {
            get
            {
                return kunde;
            }
            set
            {
                if(kunde != value)
                {
                    kunde = value;
                    OnPropertyChanged(nameof(Kunde));
                }
            }
        }
        public DateTime RowVersion
        {
            get
            {
                return rowversion;
            }
            set
            {
                if(rowversion != value)
                {
                    rowversion = value;
                    OnPropertyChanged(nameof(RowVersion));                }
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

        public override string ToString()
            => $"{ReservationsNr}; {Von}; {Bis}; {Auto}; {Kunde}";

    }
}
