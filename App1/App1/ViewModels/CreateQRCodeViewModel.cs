using App1.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class CreateQRCodeViewModel : BaseViewModel
    {
        public AsyncCommand ShareCommand{ get; }
        string kq;
        public string KQ
        {
            get => kq;

            //using Mvvm helper
            set => SetProperty(ref kq, value);

        }
        public CreateQRCodeViewModel(string kq)
        {
            this.kq = kq;
            ShareCommand = new AsyncCommand(ShareAnother);
        }

        async Task ShareAnother()
        {

            await Share.RequestAsync(new ShareTextRequest
            {
                Text = kq,
                Title = "Share Text"
            });
        }
    }
}