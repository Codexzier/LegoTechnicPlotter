using System;
using System.Text;

namespace LegoTechnicPlotter.Components.ImageToGraph
{
    public class ImageToGraphConverterException : Exception
    {
        public ImageToGraphConverterException()
        {
        }

        public ImageToGraphConverterException(string message)
            : base(message)
        {
        }

        public ImageToGraphConverterException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
