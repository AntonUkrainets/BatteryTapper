using CoreGraphics;
using Foundation;
using System;
using UIKit;

namespace BatteryTapper
{
    public partial class DrawView : UIView
    {
        public nfloat _endPointBar { get; set; }

        public string DisplayPercent { get; set; }

        private nfloat _endPoint;
        private FigureType _figureType;
        private nfloat _x;
        private nfloat _y;

        public nfloat X
        {
            get => _x;
            set
            {
                _x = value;
                SetNeedsDisplay();
            }
        }
        public nfloat Y
        {
            get => _y;
            set
            {
                _y = value;
                SetNeedsDisplay();
            }
        }
        public FigureType FigureType
        {
            get => _figureType;
            set
            {
                _figureType = value;
                SetNeedsDisplay();
            }
        }

        public nfloat EndPoint
        {
            get
            {
                return _endPoint;
            }
            set
            {
                _endPoint = value;
                SetNeedsDisplay();
            }
        }

        public DrawView(IntPtr handle) : base(handle)
        {
            _figureType = FigureType.Circle;

            DisplayPercent = "0%";
        }

        public override void Draw(CGRect rect)
        {
            switch (FigureType)
            {
                case FigureType.Circle:
                    DrawCircle();
                    DrawCircleText();
                    break;
                case FigureType.Simple:
                    DrawRectangle();
                    DrawRectText();
                    break;
                case FigureType.Bar:
                    DrawBar();
                    
                    break;
            }
        }

        private void DrawBarText(nfloat stepInBar)
        {
            var attributes = PaintStyle.GetTextAttributes();
            var text = new NSAttributedString(DisplayPercent, attributes);
            var size = text.Size;

            var textPoint = PaintStyle.DrawBarText(Bounds, size, stepInBar);
            text.DrawString(textPoint);
        }

        private void DrawRectText()
        {
            var attributes = PaintStyle.GetTextAttributes();
            var text = new NSAttributedString(DisplayPercent, attributes);
            var size = text.Size;

            var textPoint = PaintStyle.DrawRectText(Bounds.GetMidX(), size, _endPoint);
            text.DrawString(textPoint);
        }

        private void DrawBar()
        {
            int length = (int)_endPointBar / 10;
            nfloat stepInBar = 0;

            for (int i = 0; i < length; i++)
            {
                var rect = BatteryTapper.Draw.RectBar(Bounds, stepInBar);
                PaintStyle.SetBezierPath(FigureType.Bar, rect);

                stepInBar += Bounds.GetMaxY() / 16;
            }

            DrawBarText(stepInBar);
        }

        private void DrawRectangle()
        {
            var rect = BatteryTapper.Draw.RectSimple(Bounds, _endPoint);
            PaintStyle.SetBezierPath(FigureType.Simple, rect);
        }

        private void DrawCircle()
        {
            _endPointBar = (nfloat)Math.PI * 1.5f + (Y - X) / 50 * (nfloat)Math.PI * 2f;

            DisplayPercent = $"{((int)_endPointBar)}%";

            var rect = BatteryTapper.Draw.RectCircle(Bounds);

            PaintStyle.SetBezierPathForCirlce(rect, Bounds, _endPointBar);
        }

        private void DrawCircleText()
        {
            var attributes = PaintStyle.GetTextAttributes();
            var text = new NSAttributedString(DisplayPercent, attributes);
            var size = text.Size;

            var textPoint = PaintStyle.DrawCircleText(Bounds, size);
            text.DrawString(textPoint);
        }
    }
}