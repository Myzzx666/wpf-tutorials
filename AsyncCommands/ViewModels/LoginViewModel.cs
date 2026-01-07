using AsyncCommands.Commands;
using AsyncCommands.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AsyncCommands.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        //模拟IsLoading登录
        private string _statusMessage;
        public string StatusMessage
        {
            get
            {
                return _statusMessage;
            }
            set
            {
                _statusMessage = value;
                OnPropertyChanged(nameof(StatusMessage));
                OnPropertyChanged(nameof(HasStatusMessage));
            }
        }

        public bool HasStatusMessage => !string.IsNullOrEmpty(StatusMessage);

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            //LoginCommand = new LoginCommand(this, new AuthenticationService(), (ex) => StatusMessage = ex.Message);
            LoginCommand = new AsyncRelayCommand(Login, (ex) => StatusMessage = ex.Message);
        }

        private async Task Login()
        {
            StatusMessage = "Logging in...";

            await Task.Delay(3000);
            await new AuthenticationService().Login(Username);

            StatusMessage = "Successfully logged in.";
        }
    }
}
