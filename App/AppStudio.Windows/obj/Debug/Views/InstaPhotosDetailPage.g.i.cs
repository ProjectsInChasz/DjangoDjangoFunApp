﻿

#pragma checksum "C:\Users\Pawel\Desktop\App\AppStudio.Windows\Views\InstaPhotosDetailPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4CD0767507173575C33F7CE3C67C48B5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppStudio.Views
{
    partial class InstaPhotosDetail : global::Windows.UI.Xaml.Controls.Page
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.FlipView Flip; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Border HeaderHost; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.VisualState SnappedView; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.VisualState PortraitView; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.VisualState FullscreenView; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private bool _contentLoaded;

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent()
        {
            if (_contentLoaded)
                return;

            _contentLoaded = true;
            global::Windows.UI.Xaml.Application.LoadComponent(this, new global::System.Uri("ms-appx:///Views/InstaPhotosDetailPage.xaml"), global::Windows.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application);
 
            Flip = (global::Windows.UI.Xaml.Controls.FlipView)this.FindName("Flip");
            HeaderHost = (global::Windows.UI.Xaml.Controls.Border)this.FindName("HeaderHost");
            SnappedView = (global::Windows.UI.Xaml.VisualState)this.FindName("SnappedView");
            PortraitView = (global::Windows.UI.Xaml.VisualState)this.FindName("PortraitView");
            FullscreenView = (global::Windows.UI.Xaml.VisualState)this.FindName("FullscreenView");
        }
    }
}



