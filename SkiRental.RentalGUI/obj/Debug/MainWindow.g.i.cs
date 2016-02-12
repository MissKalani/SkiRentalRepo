﻿#pragma checksum "..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "74DCD7E29A1982D383D9FE9B524A0D53"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SkiRental.RentalGUI;
using SkiRental.RentalGUI.ViewModels;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace SkiRental.RentalGUI {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Input.CommandBinding Exit;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Input.CommandBinding Update;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Input.CommandBinding OpenRental;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Input.CommandBinding Return;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Input.CommandBinding About;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgAvailableEquipment;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgRentedEquipment;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SkiRental.RentalGUI;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\MainWindow.xaml"
            ((SkiRental.RentalGUI.MainWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Exit = ((System.Windows.Input.CommandBinding)(target));
            
            #line 11 "..\..\MainWindow.xaml"
            this.Exit.CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.Exit_CanExecute);
            
            #line default
            #line hidden
            
            #line 11 "..\..\MainWindow.xaml"
            this.Exit.Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.Exit_Executed);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Update = ((System.Windows.Input.CommandBinding)(target));
            
            #line 12 "..\..\MainWindow.xaml"
            this.Update.CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.Update_CanExecute);
            
            #line default
            #line hidden
            
            #line 12 "..\..\MainWindow.xaml"
            this.Update.Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.Update_Executed);
            
            #line default
            #line hidden
            return;
            case 4:
            this.OpenRental = ((System.Windows.Input.CommandBinding)(target));
            
            #line 13 "..\..\MainWindow.xaml"
            this.OpenRental.CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.OpenRental_CanExecute);
            
            #line default
            #line hidden
            
            #line 13 "..\..\MainWindow.xaml"
            this.OpenRental.Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.OpenRental_Executed);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Return = ((System.Windows.Input.CommandBinding)(target));
            
            #line 14 "..\..\MainWindow.xaml"
            this.Return.CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.Return_CanExecute);
            
            #line default
            #line hidden
            
            #line 14 "..\..\MainWindow.xaml"
            this.Return.Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.Return_Executed);
            
            #line default
            #line hidden
            return;
            case 6:
            this.About = ((System.Windows.Input.CommandBinding)(target));
            
            #line 15 "..\..\MainWindow.xaml"
            this.About.CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.About_CanExecute);
            
            #line default
            #line hidden
            
            #line 15 "..\..\MainWindow.xaml"
            this.About.Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.About_Executed);
            
            #line default
            #line hidden
            return;
            case 7:
            this.dgAvailableEquipment = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.dgRentedEquipment = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

