using NumericalMethods.Interpolation;
using NumericalMethods.UnitTests.InterpolationTests.TestData;

namespace NumericalMethods.UnitTests.InterpolationTests;

public class LagrangeTests
{
    [Theory]
    [ClassData(typeof(InterpolateLagrangeTestData))]
    public void Interpolate_GivenValidInputs_ReturnsCorrectResult(InterpolateLagrangeTestData testData)
    {
        // Act
        double result = Lagrange.Interpolate(testData.XInput, testData.XValues, testData.YValues);
        
        // Assert
        Assert.Equal(testData.ExpectedY, result, 0.00001);
    }

    [Theory]
    [InlineData(1, new double[] { 15 }, new double[] { 15 })]
    [InlineData(15, new double[] { 89 }, new double[] { })]
    [InlineData(15, new double[] { }, new double[] { 0 })]
    [InlineData(15, new double[] { }, new double[] { })]
    [InlineData(0, new double[] { 13, 12 }, new double[] { })]
    [InlineData(45, new double[] { }, new double[] { 57, 12, 15 })]
    [InlineData(14, new double[] { 57, 12, 15 }, new double[] { })]
    public void Interpolate_GivenInvalidInputs_ThrowsArgumentException(double xInput, double[] xValues, double[] yValues)
    {
        // Assert
        Assert.Throws<ArithmeticException>(() => Lagrange.Interpolate(xInput, xValues, yValues));
    }
}