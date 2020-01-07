using CoreGraphics;
using Foundation;
using System;
using UIKit;

namespace BatteryTapper
{
    public partial class ViewController : UIViewController, IUIGestureRecognizerDelegate
    {
        private nfloat _percentView;
        CGPoint location;


        public ViewController(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            _percentView = (MainView.Bounds.GetMaxY() / 2) / 100;

            var tabGesture = new UITapGestureRecognizer(Tap);
            var panGesture = new UIPanGestureRecognizer(Pan);

            MainView.AddGestureRecognizer(tabGesture);


            MainView.AddGestureRecognizer(panGesture);
        }

        private void Pan(UIPanGestureRecognizer gesture)
        {
            location = gesture.LocationInView(MainView);
            MyTouchScreenEvent();

            SetValues();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        partial void SimpleButton_Tapped(UIButton sender)
        {
            MainView.FigureType = FigureType.Simple;
            SetValues();
        }

        partial void CircleButton_Tapped(UIButton sender)
        {
            MainView.FigureType = FigureType.Circle;
            SetValues();
        }

        partial void BarButton_Tapped(UIButton sender)
        {
            MainView.FigureType = FigureType.Bar;
            SetValues();
        }

        private void SetValues()
        {
            var value = (int)(150 - MainView.EndPoint / _percentView);

            MainView.DisplayPercent = $"{value}%";
            MainView._endPointBar = value;
        }
        private void Tap(UITapGestureRecognizer gesture)
        {
            location = gesture.LocationInView(MainView);

            if (MainView.FigureType == FigureType.Circle)
            {
                MainView.X = location.X;
                MainView.Y = location.Y;
            }

            if (gesture.State == UIGestureRecognizerState.Ended)
                MyTouchScreenEvent();

            SetValues();
        }

        private void MyTouchScreenEvent()
        {
            var endPoint = MainView.Bounds.GetMaxY() / 4;

            if (location.Y <= endPoint)
                MainView.EndPoint = endPoint;
            else if (location.Y >= endPoint * 3)
                MainView.EndPoint = endPoint * 3;
            else
                MainView.EndPoint = location.Y;
        }
    }
}