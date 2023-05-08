using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using GamingGroupFinder;
using GamingGroupFinderGUI.Models;
using ReactiveUI;

namespace GamingGroupFinderGUI.ViewModels
{
    public class ResetPasswordViewModel : ViewModelBase
    {
        public ReactiveCommand<Unit, Unit> Ok { get; }
        private string _oldPassword;
        private string _newPassword;
        private string _retypeNewPassword;
        public string OldPassword {
            get => _oldPassword;
            private set => this.RaiseAndSetIfChanged(ref _oldPassword, value);
        }
        public string NewPassword {
            get => _newPassword;
            private set => this.RaiseAndSetIfChanged(ref _newPassword, value);
        }
        public string RetypeNewPassword {
            get => _retypeNewPassword;
            private set => this.RaiseAndSetIfChanged(ref _retypeNewPassword, value);
        }
        public UserDB User { get; }
        public ResetPasswordViewModel(UserDB u)
        {
            var buttonEnabled = this.WhenAnyValue(
                x => x.OldPassword,
                x => !string.IsNullOrWhiteSpace(x)
            );
            buttonEnabled = this.WhenAnyValue(
                x => x.NewPassword,
                x => !string.IsNullOrWhiteSpace(x)
            );
            buttonEnabled = this.WhenAnyValue(
                x => x.RetypeNewPassword,
                x => !string.IsNullOrWhiteSpace(x)
            );
            User = u;
            Ok = ReactiveCommand.Create(() => {
                if(ValidatePassword()) {
                    return;
                }
            }, buttonEnabled);
        }

        public bool ValidatePassword() {
            string oldPasswordHash = LogInViewModel.GenerateHash(OldPassword, User.Salt);
            if(oldPasswordHash.Equals(User.Password)) {
                if(NewPassword.Equals(RetypeNewPassword)) {
                    UserManager.GetInstance().ChangePassword(NewPassword);
                    return true;
                }
            }
            return false;
        }

    }
}