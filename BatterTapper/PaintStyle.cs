using System;
using CoreGraphics;
using UIKit;

namespace BatteryTapper
{
    public class PaintStyle
    {
        public static CGPoint DrawBarText(CGRect Bounds, CGSize size, nfloat stepInBar)
        {
            var x = Bounds.GetMidX() - size.Width / 2;
            var y = Bounds.GetMaxY() - Bounds.GetMaxY() / 4 - stepInBar - Bounds.GetMaxY() / 30 - size.Height / 2;

            var rect = new CGPoint(x, y);

            return rect;
        }

        public static CGPoint DrawRectText(nfloat midX, CGSize size, nfloat endPoint)
        {
            var x = midX - size.Width / 2;
            var y = endPoint - 50 - size.Height / 2;

            var rect = new CGPoint(x, y);

            return rect;
        }

        public static CGPoint DrawCircleText(CGRect Bounds, CGSize size)
        {
            var x = Bounds.GetMidX() - size.Width / 2;
            var y = Bounds.GetMidY() - size.Height / 2;

            var textPoint = new CGPoint(x, y);

            return textPoint;
        }

        public static UIStringAttributes GetTextAttributes()
        {
            var attributes = new UIStringAttributes
            {
                Font = UIFont.SystemFontOfSize(40),
                ForegroundColor = UIColor.White
            };

            return attributes;
        }

        public static void SetBezierPath(FigureType figureType, CGRect rect)
        {
            UIBezierPath bezierPath = new UIBezierPath();

            switch (figureType)
            {
                case FigureType.Simple:
                    bezierPath = UIBezierPath.FromRect(rect);
                    break;
                case FigureType.Bar:
                    bezierPath = UIBezierPath.FromRoundedRect(rect, cornerRadius: 10);
                    break;
            }

            bezierPath.LineWidth = 10;
            bezierPath.Stroke();
            bezierPath.Fill();
        }

        public static void SetBezierPathForCirlce(CGPoint rect, CGRect Bounds, nfloat endPointBar)
        {
            var bezierPath = new UIBezierPath();

            bezierPath.AddArc(rect, (nfloat)Math.Min(Bounds.Width, Bounds.Height) * 0.45f,
                (nfloat)Math.PI * 1.5f, endPointBar / 100 * (nfloat)Math.PI * 2f, true);
            bezierPath.LineWidth = 40;
            bezierPath.Stroke();
        }
    }
}