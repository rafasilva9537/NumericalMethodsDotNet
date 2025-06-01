namespace NumericalMethods.Interpolation;

/// <summary>
/// All Lagrange interpolation related methods.
/// </summary>
public static class Lagrange
{
    /// <summary>
    /// Evaluate the Lagrange interpolation polynomial at given x-value.
    /// </summary>
    /// <param name="x">Input x value which will be evaluated.</param>
    /// <param name="xValues">The known x-values of the data points.</param>
    /// <param name="yValues">The known y-values corresponding to <paramref name="xValues"/>.</param>
    /// <returns>The interpolated y-value at <paramref name="x"/></returns>
    /// <exception cref="ArithmeticException">
    /// Thrown when <paramref name="xValues"/> and <paramref name="yValues"/> don't have the same lenght, or when one of them contain fewer than two points.
    /// </exception>
    public static double Interpolate(double x, IEnumerable<double> xValues, IEnumerable<double> yValues)
    {
        var xsArray = xValues as double[] ?? xValues.ToArray();
        var ysArray = yValues as double[] ?? yValues.ToArray();
        
        if(xsArray.Length != ysArray.Length) throw new ArithmeticException("xValues and yValues must have the same length");
        if(xsArray.Length < 2 || ysArray.Length < 2) throw new ArithmeticException("xValues and yValues must have at least two values");

        double yPolynomial = 0;
        
        for (int i = 0; i < ysArray.Length; i++)
        {
            double lagrangeBasis = 1;    
            double xNow = xsArray[i];
            
            for (int j = 0; j < xsArray.Length; j++)
            {
                if(xNow.Equals(xsArray[j])) continue;
                lagrangeBasis *= (x - xsArray[j]) / (xNow - xsArray[j]);
            }
            
            yPolynomial += lagrangeBasis * ysArray[i];
        }
        
        return yPolynomial;
    }

    public static double[] GetPolynomialCoefficients(IEnumerable<double> xValues, IEnumerable<double> yValues)
    {
        // TODO: implement method
        throw new NotImplementedException();
    }
}