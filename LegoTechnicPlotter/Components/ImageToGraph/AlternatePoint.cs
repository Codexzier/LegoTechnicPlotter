using System;
using Microsoft.SPOT;
using System.Collections;

namespace LegoTechnicPlotter.Components.ImageToGraph
{
    public class AlternatePoint
    {
        public DrawPointItem ScanToNextPossiblePoint(Bitmap bitmap, int iY, int iX, int threshold, int range)
        {
            Logging.Log("Scan to next possible point: Y:" + iY.ToString() + ", X:" +iX.ToString());

            var rad = range / 2;

            if (rad == 0)
            {
                rad = 1;
            }

            // list of DrawPointItem
            var collect = new ArrayList();

            for (int iRangeY = iY - rad; iRangeY < iY + rad; iRangeY++)
            {
                for (int iRangeX = iX - rad; iRangeX < iX + rad; iRangeX++)
                {
                    int targetY = iRangeY;
                    int targetX = iRangeX;

                    if (targetY < 0)
                    {
                        targetY = 0;
                    }

                    if (targetY >= bitmap.Height)
                    {
                        targetY = bitmap.Height - 1;
                    }

                    if (targetX < 0)
                    {
                        targetX = 0;
                    }

                    if (targetX >= bitmap.Width)
                    {
                        targetX = bitmap.Width - 1;
                    }

                    var t = ImageToGraphHelper.GrayScale(bitmap.GetPixel(targetX, targetY));
                    collect.Add(new DrawPointItem(targetX, targetY, t));
                }
            }

            Logging.Log("Min draw point gray scale");
            var max = collect.MinDrawPointGrayScale();
            Logging.Log("- Result: " + max.ToString());

            if (collect.AllGrayScaleValueEqual(max))
            {
                var t = ImageToGraphHelper.GrayScale(bitmap.GetPixel(iX, iY));
                return new DrawPointItem(iX, iY, t);
            }

            var result = collect.FirstByGrayScaleLowerOrEqualThan(max); 

            return result;
        }
    }
}
