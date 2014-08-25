using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.WebBrowser;
using Cirrious.MvvmCross.ViewModels;
using StackSnapMvvmCross.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

using Plugin.Dralle;




namespace StackSnapMvvmCross.Core.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {


        private readonly IDralle _dralleService;

             

        public LoginViewModel(IDralle dralleService)
        {
            _dralleService = dralleService;

 
            string t = "";
        }

        private string _serverId = ""; 
        public string ServerId
        {
            get { return _serverId; }
            set { _serverId = value; RaisePropertyChanged(() => ServerId); }
        }

        private string _userName = "";
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; RaisePropertyChanged(() => UserName); }
        }

        private string _password = "";    
        public string Password
        {
            get { return _password; }
            set { _password = value; RaisePropertyChanged(() => Password); }
        }

        private Cirrious.MvvmCross.ViewModels.MvxCommand _executeLogin;
        public System.Windows.Input.ICommand DoLogin
        {
            get
            {
                _executeLogin = _executeLogin ?? new Cirrious.MvvmCross.ViewModels.MvxCommand(ExecuteLogin);
                return _executeLogin;
            }
        }

        public void ExecuteLogin()
        {
            
            string t = "Ole";




  //          api = new APIAccess(ServerId, UserName, Password);
            
            
            Task.Factory.StartNew(() =>
            {
                 _dralleService.ping( ServerId, UserName, Password);

            });

        }

        private Cirrious.MvvmCross.ViewModels.MvxCommand _executeAbout;
        public System.Windows.Input.ICommand DoAbout
        {
            get
            {
                _executeAbout = _executeAbout ?? new Cirrious.MvvmCross.ViewModels.MvxCommand(ExecuteAbout);
                return _executeAbout;
            }
        }

        private void ExecuteAbout()
        {
           
            var task = Mvx.Resolve<IMvxWebBrowserTask>();
            task.ShowWebPage("http://www.dralle.dk");
        }

        
        private void Recalc()
        {
     
        }
   

    
    }
}
