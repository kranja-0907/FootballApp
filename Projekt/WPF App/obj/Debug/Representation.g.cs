#pragma checksum "..\..\Representation.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DDA9E305806A170D25129864F5C662D8F90546D3A33DFC3B8C8A2DD0AC3D7C9A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
using WPF_App;
using WPF_App.Properties;


namespace WPF_App {
    
    
    /// <summary>
    /// Representation
    /// </summary>
    public partial class Representation : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\Representation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblCountry;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\Representation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblFifaCode;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\Representation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblGamesPlayed;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\Representation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblGamesWon;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\Representation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblGamesLost;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\Representation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblDraws;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\Representation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblGoalsFor;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\Representation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblGoalsAgainst;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\Representation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblGoalsDiff;
        
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
            System.Uri resourceLocater = new System.Uri("/WPF App;component/representation.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Representation.xaml"
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
            
            #line 9 "..\..\Representation.xaml"
            ((WPF_App.Representation)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lblCountry = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.lblFifaCode = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.lblGamesPlayed = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.lblGamesWon = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.lblGamesLost = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.lblDraws = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.lblGoalsFor = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.lblGoalsAgainst = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.lblGoalsDiff = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

