using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AutoReservation.Common.DataTransferObjects;

namespace AutoReservation.Ui.ViewModels
{
    public class ReservationenViewModel
        : ViewModelBase
    {

        private readonly List<ReservationDto> _reservationsOriginal = new List<ReservationDto>();
        private ObservableCollection<ReservationDto> _reservations;
        public ObservableCollection<ReservationDto> Reservations
        {
            get
            {
                if (_reservations == null)
                {
                    _reservations = new ObservableCollection<ReservationDto>();
                }
                return _reservations;
            }
        }

        public IEnumerable<KundeDto> Kunden
        {
            get
            {
                return Service.FindAllKunden();
            }
        }

        public IEnumerable<AutoDto> Autos
        {
            get
            {
                return Service.FindAllAutos();
            }
        }

        private ReservationDto _selectedRes;
        public ReservationDto SelectedReservation
        {
            get { return _selectedRes; }
            set
            {
                if (_selectedRes == value) return;
                _selectedRes = value;
                RaisePropertyChanged();
            }
        }

        #region Load-Command

        private RelayCommand _loadCommand;

        public ICommand LoadCommand
        {
            get
            {
                if (_loadCommand == null)
                {
                    _loadCommand = new RelayCommand(
                        param => Load(),
                        param => CanLoad()
                    );
                }
                return _loadCommand;
            }
        }

        protected override void Load()
        {
            Reservations.Clear();
            _reservationsOriginal.Clear();
            foreach (var res in Service.Reservationen)
            {
                Reservations.Add(res);
                _reservationsOriginal.Add((ReservationDto)res.Clone());
            }
            SelectedReservation = Reservations.FirstOrDefault();
        }

        private bool CanLoad()
        {
            return Service != null;
        }

        #endregion

        #region Save-Command

        private RelayCommand _saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(
                        param => SaveData(),
                        param => CanSaveData()
                    );
                }
                return _saveCommand;
            }
        }

        private void SaveData()
        {
            foreach (var res in Reservations)
            {
                if (res.ReservationNr == default(int))
                {
                    Service.InsertReservation(res);
                }
                else
                {
                    var original = _reservationsOriginal.FirstOrDefault(t => t.ReservationNr == res.ReservationNr);
                    Service.UpdateReservation(original, res);
                }
            }
            Load();
        }

        private bool CanSaveData()
        {
            if (Service == null)
            {
                return false;
            }

            var errorText = new StringBuilder();
            foreach (var res in Reservations)
            {
                var error = res.Validate();
                if (string.IsNullOrEmpty(error)) continue;
                errorText.AppendLine(res.ToString());
                errorText.AppendLine(error);
            }

            ErrorText = errorText.ToString();
            return string.IsNullOrEmpty(ErrorText);
        }

        #endregion

        #region New-Command

        private RelayCommand _newCommand;

        public ICommand NewCommand
        {
            get
            {
                if (_newCommand == null)
                {
                    _newCommand = new RelayCommand(
                        param => New(),
                        param => CanNew()
                    );
                }
                return _newCommand;
            }
        }

        private void New()
        {
            Reservations.Add(new ReservationDto());
        }

        private bool CanNew()
        {
            return Service != null;
        }

        #endregion

        #region Delete-Command

        private RelayCommand deleteCommand;

        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand(
                        param => Delete(),
                        param => CanDelete()
                    );
                }
                return deleteCommand;
            }
        }

        private void Delete()
        {
            Service.DeleteReservation(SelectedReservation);
            Load();
        }

        private bool CanDelete()
        {
            return
                SelectedReservation != null &&
                SelectedReservation.ReservationNr != default(int) &&
                Service != null;
        }

        #endregion
    }
}
