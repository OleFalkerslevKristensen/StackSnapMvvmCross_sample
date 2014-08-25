using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using StackSnapMvvmCross.Core.Services;
using System;

namespace StackSnapMvvmCross.Core.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {
        

        private string _welcome;
        public string Welcome
        {
            get { return _welcome; }
            set { _welcome = value; RaisePropertyChanged(() => Welcome); }
        }


        private string _applicationId;
        public string ApplicationId
        {
            get { return _applicationId; }
            set { _applicationId = value; RaisePropertyChanged(() => ApplicationId); }
        }
        
     
        private Cirrious.MvvmCross.ViewModels.MvxCommand _myCommand;
        public System.Windows.Input.ICommand MyCommand
        {
            get
            {
                _myCommand = _myCommand ?? new Cirrious.MvvmCross.ViewModels.MvxCommand(DoMyCommand);
                return _myCommand;
            }
        }

        public void doWelcome(string welcome)
        {
            _welcome = welcome;
        }

        private void DoMyCommand()
        {
   //         Hello = Hello + " World";
        }

        private Cirrious.MvvmCross.ViewModels.MvxCommand _goLoginCommand;
        public System.Windows.Input.ICommand GoLoginCommand
        {
            get
            {
                _goLoginCommand = _goLoginCommand ?? new Cirrious.MvvmCross.ViewModels.MvxCommand(DoLogin);
                return _goLoginCommand;
            }
        }

        public void DoLogin()
        {

            try
            {

                ShowViewModel<LoginViewModel>();
            }
            catch (Exception exc)
            {
                string t = exc.Message;
            }


        }



    }
}
