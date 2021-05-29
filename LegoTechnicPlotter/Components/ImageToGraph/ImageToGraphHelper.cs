using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation.Media;
using System.Collections;

namespace LegoTechnicPlotter.Components.ImageToGraph
{
    public static class ImageToGraphHelper
    {
        public static int GrayScale(Color pixel)
        {
            return (int)((ColorUtility.GetRValue(pixel) * 0.3) + (ColorUtility.GetBValue(pixel) * 0.59) + (ColorUtility.GetBValue(pixel) * 0.11));
        }

        public static int Normalize(int rangeResult, int max)
        {
            if (rangeResult < 0)
            {
                return 0;
            }

            if (rangeResult > max)
            {
                return max;
            }

            return rangeResult;
        }

        public static int MinDrawPointGrayScale(this ArrayList list)
        {
            int min = int.MaxValue;

            foreach (DrawPointItem item in list)
            {
                if (item.GrayScaleValue < min)
                {
                    min = item.GrayScaleValue;
                }
            }

            return min;
        }

        public static bool AllGrayScaleValueEqual(this ArrayList list, int value)
        {
            foreach (DrawPointItem item in list)
            {
                if (item.GrayScaleValue != value)
                {
                    return false;
                }
            }

            return true;
        }

        public static DrawPointItem FirstByGrayScaleLowerOrEqualThan(this ArrayList list, int value)
        {
            if (list.Count == 0)
            {
                return null;
            }

            foreach (DrawPointItem item in list)
            {
                if (item.GrayScaleValue != value)
                {
                    return item;
                }
            }

            return null;
        }

        public static ArrayList FilterDoublePositions(this ArrayList list)
        {
            Logging.Log("Filter double positions. Arraylist: " + list.Count.ToString());

            ArrayList newList = new ArrayList();

            foreach (DrawPointItem itemSource in list)
            {
                bool exist = false;
                foreach (DrawPointItem item in newList)
                {
                    if (item.X == itemSource.X && item.Y == itemSource.Y)
                    {
                        exist = true;
                        break;
                    }
                }

                if (!exist)
                {
                    newList.Add(itemSource);
                }
            }


            return newList;
        }
    }
}
