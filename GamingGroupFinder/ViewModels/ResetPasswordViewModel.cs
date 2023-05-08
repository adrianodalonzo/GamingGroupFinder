using System.Collections.Generic;
using System.Collections.ObjectModel;
using GamingGroupFinderGUI.Models;

namespace GamingGroupFinderGUI.ViewModels
{
    public class ResetPasswordViewModel : ViewModelBase
    {
        public ResetPasswordViewModel(UserDB u)
        {
            User = u;
        }

        public UserDB User { get; }
    }
}