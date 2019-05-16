using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnywhereChecklist.Apps.Components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckBoxView : Frame
    {

        public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create(
                                                nameof(IsChecked), typeof(bool), typeof(CheckBoxView), null,
                                                propertyChanged: CheckChanged);
        private bool isChecked;

        public bool IsChecked
        {
            get => isChecked;
            set
            {
                isChecked = value;
                if (value) BackgroundColor = Color.LawnGreen;
                else BackgroundColor = Color.Default;
            }
        }

        public CheckBoxView()
        {
            InitializeComponent();
        }

        private static void CheckChanged(BindableObject obj, object oldVal, object newVal)
        {
            ((CheckBoxView)obj).IsChecked = (bool)newVal;
        }

    }
}