using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using UIKit;

namespace BatteryTapper
{
    public class Draw
    {
        public static CGRect RectBar(CGRect Bounds, nfloat stepInBar)
        {
            var x = Bounds.GetMidX() - Bounds.GetMaxX() / 4;
            var y = Bounds.GetMaxY() - Bounds.GetMaxY() / 4 - Bounds.GetMaxY() / 25 - stepInBar;

            var width = Bounds.GetMaxX() / 2;
            var height = Bounds.GetMaxY() / 20;

            var rect = new CGRect(x, y, width, height);

            return rect;
        }

        public static CGRect RectSimple(CGRect Bounds, nfloat endPoint)
        {
            var x = Bounds.GetMidX() - Bounds.GetMaxX() / 4;
            var y = endPoint;

            var width = Bounds.GetMaxX() / 2;
            var height = Bounds.GetMaxY() - Bounds.GetMaxY() / 4 - endPoint;

            var rect = new CGRect(x, y, width, height);

            return rect;
        }

        public static CGPoint RectCircle(CGRect Bounds)
        {
            var x = Bounds.GetMidX();
            var y = Bounds.GetMidY();

            var rect = new CGPoint(x, y);

            return rect;
        }
    }
}