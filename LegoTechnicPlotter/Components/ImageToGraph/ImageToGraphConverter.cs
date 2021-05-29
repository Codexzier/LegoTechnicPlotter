using System;
using Microsoft.SPOT;
using System.Collections;

namespace LegoTechnicPlotter.Components.ImageToGraph
{
    public class ImageToGraphConverter
    {
        public IDictionary Convert(Bitmap bitmap, int threshold, int range, ImageToGraphState state)
        {
            Logging.Log("Image to graph Convert");

            if(state == null)
            {
                throw new ImageToGraphConverterException("state must be instatiated");
            }

            state.Progress = 0;
            state.ProgressEnd = bitmap.Height;

            var alt = new AlternatePoint();
            var toGray = new BitmapToGray();
            var r = toGray.Convert(bitmap, threshold, range);

            // list of DrawPointItem
            var sequenz = new ArrayList();

            bool goToRight = true;
            for (int iY = 0; iY < r.Height; iY++)
            {
                Logging.Log("Row: " + iY.ToString());

                if (goToRight)
                {
                    for (int iX = 0; iX < r.Width; iX++)
                    {
                        var dpi = alt.ScanToNextPossiblePoint(bitmap, iY, iX, threshold, range);
                        
                        if (dpi == null)
                        {
                            continue;
                        }

                        sequenz.Add(dpi);
                    }
                }
                else
                {
                    for (int iX = r.Width - 1; iX >= 0; iX--)
                    {
                        var dpi = alt.ScanToNextPossiblePoint(bitmap, iY, iX, threshold, range);

                        if (dpi == null)
                        {
                            continue;
                        }

                        sequenz.Add(dpi);
                    }
                }

                state.Progress++;
                goToRight = !goToRight;
            }

            var filteredSequenz = sequenz.FilterDoublePositions();
            var dict = new DictionaryDrawPoints();

            long index = 0;
            foreach (var item in filteredSequenz)
            {
                dict.Add(index, item);
                index++;
            }
            return dict;
        }
    }
}
