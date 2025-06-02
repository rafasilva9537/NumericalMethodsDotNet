using NumericalMethods.Interpolation;
using ScottPlot;

namespace ConsoleAppTest;

internal class Program
{
    internal static void Main(string[] args)
    {
        double[][] xyValues = [
            [-1, 0, 2],
            [4, 1, -1],
        ];

        List<double> xValues = [];
        List<double> yValues = [];
        for(double i = -10;  i <= 10; i+=0.25)
        {
            double interpolatedX = i;
            double interpolatedY = Lagrange.Interpolate(interpolatedX, xyValues[0], xyValues[1]);
            xValues.Add(interpolatedX);
            yValues.Add(interpolatedY);
        }

        // var interpolatedXsYs = xValues.Zip(yValues, (f, s) => new { X = f, Y = s });
        //Console.WriteLine($"interpolatedXsYs: {JsonSerializer.Serialize(interpolatedXsYs)}");
        
        Plot myPlot = new();
        
        myPlot.Axes.SquareUnits();
        myPlot.Add.Scatter(xValues, yValues);
        
        myPlot.SavePng("my-plot.png", 400, 400);
    }
}