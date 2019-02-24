using AnywhereChecklist.Apps.Services;
using AnywhereChecklist.Apps.ViewModels;
using AnywhereChecklist.Entities;
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
    public partial class CheckListView : StackLayout
    {

        public static readonly BindableProperty CheckListProperty = BindableProperty.Create(
                                                                      propertyName: nameof(CheckList),
                                                                      returnType: typeof(string),
                                                                      declaringType: typeof(CheckList),
                                                                      defaultValue: null,
                                                                      defaultBindingMode: BindingMode.TwoWay,
                                                                      propertyChanged: (b, o, n) => b.SetValue(CheckListProperty, n));
        public CheckList CheckList
        {
            get => _viewModel?.CheckList;
            set => _viewModel.CheckList = value;
        }

        readonly CheckListsViewModel _viewModel;

        public CheckListView()
        {
            InitializeComponent();
            _viewModel = Provider.Get<CheckListsViewModel>();
            BindingContext = CheckList;
        }
    }
}