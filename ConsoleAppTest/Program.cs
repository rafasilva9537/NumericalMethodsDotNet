using System.Text.Json;
using NumericalMethods.Interpolation;

namespace ConsoleAppTest;

internal class Program
{
    internal static void Main(string[] args)
    {
        double[][] xyValues = [
            [1, 5, 3, 9, 15],
            [3, 8, 10, 9, 7],
        ];

        List<double> xValues = [];
        List<double> yValues = [];
        for(double i = 0; i < xyValues[0].Max(); i+=0.25)
        {
            double interpolatedX = i;
            double interpolatedY = Lagrange.Interpolate(interpolatedX, xyValues[0], xyValues[1]);
            xValues.Add(interpolatedX);
            yValues.Add(interpolatedY);
        }

        // var interpolatedXsYs = xValues.Zip(yValues, (f, s) => new { X = f, Y = s });
        //Console.WriteLine($"interpolatedXsYs: {JsonSerializer.Serialize(interpolatedXsYs)}");
    }
}