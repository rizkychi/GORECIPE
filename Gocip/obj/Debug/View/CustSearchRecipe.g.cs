﻿#pragma checksum "..\..\..\View\CustSearchRecipe.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C1E290BAAC9D6414FDE818CA11E3290DC9DDE34B"
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
    /// CustSearchRecipe
    /// </summary>
    public partial class CustSearchRecipe : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\View\CustSearchRecipe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearchBox;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\View\CustSearchRecipe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image btnCari;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\View\CustSearchRecipe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblNotFound;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\View\CustSearchRecipe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel TileItem;
        
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
            System.Uri resourceLocater = new System.Uri("/Gocip;component/view/custsearchrecipe.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\CustSearchRecipe.xaml"
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
            this.txtSearchBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 24 "..\..\..\View\CustSearchRecipe.xaml"
            this.txtSearchBox.GotFocus += new System.Windows.RoutedEventHandler(this.txtSearchBox_GotFocus);
            
            #line default
            #line hidden
            
            #line 24 "..\..\..\View\CustSearchRecipe.xaml"
            this.txtSearchBox.LostFocus += new System.Windows.RoutedEventHandler(this.txtSearchBox_LostFocus);
            
            #line default
            #line hidden
            
            #line 24 "..\..\..\View\CustSearchRecipe.xaml"
            this.txtSearchBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.txtSearchBox_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnCari = ((System.Windows.Controls.Image)(target));
            
            #line 25 "..\..\..\View\CustSearchRecipe.xaml"
            this.btnCari.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.btnCari_MouseDown);
            
            #line default
            #line hidden
            
            #line 25 "..\..\..\View\CustSearchRecipe.xaml"
            this.btnCari.MouseEnter += new System.Windows.Input.MouseEventHandler(this.btnCari_MouseEnter);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lblNotFound = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.TileItem = ((System.Windows.Controls.WrapPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

