﻿#pragma checksum "..\..\..\Pages\Voucher.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "68E734ECC4784DE3EAB426B8CAD954E3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18033
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace Travel_agency.Pages {
    
    
    /// <summary>
    /// Voucher
    /// </summary>
    public partial class Voucher : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\Pages\Voucher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridRoutes;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Pages\Voucher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button updateBtn;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Pages\Voucher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteBtn;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Pages\Voucher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tour_nTB;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Pages\Voucher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button updateBtn_Copy;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Pages\Voucher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label countryLbl;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Pages\Voucher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox countryCmb;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Pages\Voucher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label cityLbl;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Pages\Voucher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cityCmb;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\Pages\Voucher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addBtn;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\Pages\Voucher.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button delBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/Travel_agency;component/pages/voucher.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\Voucher.xaml"
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
            
            #line 6 "..\..\..\Pages\Voucher.xaml"
            ((Travel_agency.Pages.Voucher)(target)).Loaded += new System.Windows.RoutedEventHandler(this.OnInit);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dataGridRoutes = ((System.Windows.Controls.DataGrid)(target));
            
            #line 16 "..\..\..\Pages\Voucher.xaml"
            this.dataGridRoutes.AutoGeneratedColumns += new System.EventHandler(this.hideCol);
            
            #line default
            #line hidden
            return;
            case 3:
            this.updateBtn = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.deleteBtn = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.tour_nTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.updateBtn_Copy = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\Pages\Voucher.xaml"
            this.updateBtn_Copy.Click += new System.Windows.RoutedEventHandler(this.updateBtn_Copy_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.countryLbl = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.countryCmb = ((System.Windows.Controls.ComboBox)(target));
            
            #line 33 "..\..\..\Pages\Voucher.xaml"
            this.countryCmb.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.countryCmb_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.cityLbl = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.cityCmb = ((System.Windows.Controls.ComboBox)(target));
            
            #line 36 "..\..\..\Pages\Voucher.xaml"
            this.cityCmb.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cityCmb_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 39 "..\..\..\Pages\Voucher.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 47 "..\..\..\Pages\Voucher.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            return;
            case 13:
            this.addBtn = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\..\Pages\Voucher.xaml"
            this.addBtn.Click += new System.Windows.RoutedEventHandler(this.Button_Click_3);
            
            #line default
            #line hidden
            return;
            case 14:
            this.delBtn = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\..\Pages\Voucher.xaml"
            this.delBtn.Click += new System.Windows.RoutedEventHandler(this.delBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

