﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnywhereChecklist.Apps
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
