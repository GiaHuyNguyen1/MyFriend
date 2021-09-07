using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyFriend.Resources.Style
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControlStyle : ResourceDictionary
    {
        public ControlStyle()
        {
            InitializeComponent();
        }
    }
}