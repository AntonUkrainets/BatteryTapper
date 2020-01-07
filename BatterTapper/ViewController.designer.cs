// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace BatteryTapper
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BarButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton CircleButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblMy { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        BatteryTapper.DrawView MainView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SimpleButton { get; set; }

        [Action ("BarButton_Tapped:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BarButton_Tapped (UIKit.UIButton sender);

        [Action ("CircleButton_Tapped:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void CircleButton_Tapped (UIKit.UIButton sender);

        [Action ("SimpleButton_Tapped:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SimpleButton_Tapped (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (BarButton != null) {
                BarButton.Dispose ();
                BarButton = null;
            }

            if (CircleButton != null) {
                CircleButton.Dispose ();
                CircleButton = null;
            }

            if (lblMy != null) {
                lblMy.Dispose ();
                lblMy = null;
            }

            if (MainView != null) {
                MainView.Dispose ();
                MainView = null;
            }

            if (SimpleButton != null) {
                SimpleButton.Dispose ();
                SimpleButton = null;
            }
        }
    }
}