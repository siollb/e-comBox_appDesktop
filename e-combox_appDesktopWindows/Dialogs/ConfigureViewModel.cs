using e_combox_appDesktopWindows.Scripts;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace e_combox_appDesktopWindows.Dialogs
{
    class ConfigureViewModel : INotifyPropertyChanged
    {
        public ICommand OpenConfigureDialogCommand { get; }
        public ICommand AcceptConfigureDialogCommand { get; }
        public ICommand CancelConfigureDialogCommand { get; }
        public ICommand OpenProgressDialogCommand { get; }

        public string AdresseIP { get; set; }
        public string AdresseProxy { get; set; }

        private bool _isConfigureDialogOpen;
        private bool _isProgressDialogOpen;
        private object _configureContent;
        private string _scriptsDirectory = string.Format(@"..\..\Scripts\");

        public ConfigureViewModel()
        {
            OpenConfigureDialogCommand = new CommandImplementation(OpenConfigureDialog);
            OpenProgressDialogCommand = new CommandImplementation(OpenProgressDialog);
            AcceptConfigureDialogCommand = new CommandImplementation(AcceptConfigureDialog);
            CancelConfigureDialogCommand = new CommandImplementation(CancelConfigureDialog);

            AdresseIP = "";
            AdresseProxy = "";
        }

        public bool IsConfigureDialogOpen
        {
            get { return _isConfigureDialogOpen; }
            set
            {
                if (_isConfigureDialogOpen == value) return;
                _isConfigureDialogOpen = value;
                OnPropertyChanged();
            }
        }

        public bool IsProgressDialogOpen
        {
            get { return _isProgressDialogOpen; }
            set
            {
                if (_isProgressDialogOpen == value) return;
                _isProgressDialogOpen = value;
                OnPropertyChanged();
            }
        }

        public object ConfigureContent
        {
            get { return _configureContent; }
            set
            {
                if (_configureContent == value) return;
                _configureContent = value;
                OnPropertyChanged();
            }
        }

        private void OpenConfigureDialog(object obj)
        {
            ConfigureContent = new ConfigureDialog();
            IsConfigureDialogOpen = true;
        }

        private void OpenProgressDialog(object obj)
        {
            ConfigureContent = new ConfigureProgressDialog();
            IsProgressDialogOpen = true;

            /*PowerShellExecution pse = new PowerShellExecution();
            string adresse = await pse.ExecuteShellScript(_scriptsDirectory + "test.ps1");

            if (adresse.Length > 0)
            {
                this.AdresseProxy = "Vous disposez d'un proxy, veuillez configurer l'adresse suivante dans Docker : " + adresse;
                ConfigureContent = new ConfigureDialog();
                IsConfigureDialogOpen = true;
            } else
            {
                IsConfigureDialogOpen = false;
            }*/
        }

        private void CancelConfigureDialog(object obj)
        {
            IsConfigureDialogOpen = false;
        }

        private void AcceptConfigureDialog(object obj)
        {
            ConfigureContent = new ConfigureProgressDialog();

            
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
