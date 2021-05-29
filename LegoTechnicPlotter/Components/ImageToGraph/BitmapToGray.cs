using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation.Media;

namespace LegoTechnicPlotter.Components.ImageToGraph
{
    public class BitmapToGray
    {
        public Bitmap Convert(Bitmap bitmap, int threshold, int range)
        {
            Logging.Log("Bitmap to gray Convert: Picture 160x120, threshold=" + threshold.ToString() + ", Range: " + range.ToString());

            var gray = new Bitmap(bitmap.Width, bitmap.Height);
            var max = 3 * 255;

            Logging.Log("Bitmab:");
            for (int iY = 0; iY < bitmap.Height; iY++)
            {
                Logging.Log("Bitmap - Y: " + iY.ToString());

                for (int iX = 0; iX < bitmap.Width; iX++)
                {
                    Logging.Log("Bitmap - X: " + iX.ToString() + ", Y:" + iY.ToString());

                    var pixel = bitmap.GetPixel(iX, iY);

                    int sum = ImageToGraphHelper.GrayScale(pixel);

                    if (sum > ImageToGraphHelper.Normalize(threshold - range, max) && sum < ImageToGraphHelper.Normalize(threshold + range, max))
                    {
                        gray.SetPixel(iX, iY, Color.Black);
                        continue;
                    }

                    if (sum < ImageToGraphHelper.Normalize(threshold - range, max) || sum > ImageToGraphHelper.Normalize(threshold + range, max))
                    {
                        gray.SetPixel(iX, iY, ColorUtility.ColorFromRGB(128, 128, 128));
                        continue;
                    }

                    gray.SetPixel(iX, iY, Color.White);
                }
            }

            return gray;
        }    
    }
}
