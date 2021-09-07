using App1.Models;
using App1.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using ZXing;

namespace App1.ViewModels
{
    public class ScanQRViewModel : BaseViewModel
    {
        public AsyncCommand ScanCommand { get; }

        public AsyncCommand TakeCommand { get; }

        private string barcode = string.Empty;
        public string Barcode
        {
            get
            {
                return barcode;
            }
            set
            {
                barcode = value;
            }
        }

        private bool _isAnalyzing = true;
        public bool IsAnalyzing
        {
            get { return _isAnalyzing; }
            set
            {
                if (!Equals(_isAnalyzing, value))
                {
                    _isAnalyzing = value;
                }
            }
        }

        private bool _isScanning = true;
        public bool IsScanning
        {
            get { return _isScanning; }
            set
            {
                if (!Equals(_isScanning, value))
                {
                    _isScanning = value;
                }
            }
        }
        
        Task Scan()
        {
            IsAnalyzing = false;
            IsScanning = false;

            Device.BeginInvokeOnMainThread(async () =>
            {
                Barcode = Result.Text;
                FriendModel account = JsonConvert.DeserializeObject<FriendModel>(Barcode);
                await FriendsService.AddFriend(account.Name, account.Number, account.Address, account.Email);
                List<FriendModel> _data = new List<FriendModel>();
                _data.Add(new FriendModel()
                {
                    Name = account.Name,
                    Number = account.Number,
                    Address = account.Address,
                    Email = account.Email
                });

                string json = JsonConvert.SerializeObject(_data.ToArray());
                await App.Current.MainPage.Navigation.PopAsync();
            });

            IsAnalyzing = true;
            IsScanning = true;
            return Task.CompletedTask;
        }

        async Task Take()
        {
            var image = await MediaPicker.PickPhotoAsync();
            var stream = await image.OpenReadAsync();
            var bytes = new byte[stream.Length];
            await stream.ReadAsync(bytes,0,bytes.Length);
            stream.Seek(0, System.IO.SeekOrigin.Begin);
            var results = await GoogleVisionBarCodeScanner.Methods.ScanFromImage(bytes);
            var resultString = string.Empty;
            foreach (var barcode in results)
            {
                resultString = barcode.DisplayValue;
            }
            Device.BeginInvokeOnMainThread(async () =>
            {
                Barcode = resultString;
                FriendModel account = JsonConvert.DeserializeObject<FriendModel>(Barcode);
                await FriendsService.AddFriend(account.Name, account.Number, account.Address, account.Email);
                List<FriendModel> _data = new List<FriendModel>();
                _data.Add(new FriendModel()
                {
                    Name = account.Name,
                    Number = account.Number,
                    Address = account.Address,
                    Email = account.Email
                });

                string json = JsonConvert.SerializeObject(_data.ToArray());
                await App.Current.MainPage.Navigation.PopAsync();
            });

            IsAnalyzing = true;
            IsScanning = true;
        }
        

        public Result Result { get; set; }
        public ScanQRViewModel()
        {
            Title = "Scan QR code";
            ScanCommand = new AsyncCommand(Scan);
            TakeCommand = new AsyncCommand(Take);
        }
    }
}