﻿#pragma checksum "..\..\..\View\DataRecipePage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DD05908E058A127682173DEC98A18097E67BE062"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Gocip.View;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace Gocip.View {
    
    
    /// <summary>
    /// DataRecipePage
    /// </summary>
    public partial class DataRecipePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\View\DataRecipePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblJudul;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\View\DataRecipePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnTambah;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\View\DataRecipePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUbah;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\View\DataRecipePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnHapus;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\View\DataRecipePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearch;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\View\DataRecipePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgRecipe;
        
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
            System.Uri resourceLocater = new System.Uri("/Gocip;component/view/datarecipepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\DataRecipePage.xaml"
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
            this.lblJudul = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.btnTambah = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\View\DataRecipePage.xaml"
            this.btnTambah.Click += new System.Windows.RoutedEventHandler(this.btnTambah_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnUbah = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\View\DataRecipePage.xaml"
            this.btnUbah.Click += new System.Windows.RoutedEventHandler(this.btnUbah_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnHapus = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\View\DataRecipePage.xaml"
            this.btnHapus.Click += new System.Windows.RoutedEventHandler(this.btnHapus_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 36 "..\..\..\View\DataRecipePage.xaml"
            this.txtSearch.GotFocus += new System.Windows.RoutedEventHandler(this.txtSearch_GotFocus);
            
            #line default
            #line hidden
            
            #line 36 "..\..\..\View\DataRecipePage.xaml"
            this.txtSearch.KeyDown += new System.Windows.Input.KeyEventHandler(this.txtSearch_OnKeyDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.dgRecipe = ((System.Windows.Controls.DataGrid)(target));
            
            #line 39 "..\..\..\View\DataRecipePage.xaml"
            this.dgRecipe.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.dgRecipe_LoadingRow);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
