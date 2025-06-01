using System.Collections;
using System.Collections.ObjectModel;

namespace NumericalMethods.UnitTests.InterpolationTests.TestData;

public class InterpolateLagrangeTestData() : IEnumerable<object[]>
{
    public double XInput { get; private init; }
    public IEnumerable<double> XValues { get; private init; } = null!;
    public IEnumerable<double> YValues { get; private init; } = null!;
    public double ExpectedY { get; private init; }
    
    public IEnumerator<object[]> GetEnumerator()
    {
        // Test different type of collections
        yield return
        [
            new InterpolateLagrangeTestData()
            {
                XInput = 1,
                XValues = new List<double>() {-1, 0, 2},
                YValues = [4, 1, -1],
                ExpectedY = -2 / 3d,
            },
        ];
        
        yield return
        [
            new InterpolateLagrangeTestData()
            {
                XInput = 0,
                XValues = new Collection<double>() {2, 4},
                YValues = [3.1, 5.6],
                ExpectedY = 0.6,
            },
        ];

        yield return
        [
            new InterpolateLagrangeTestData()
            {
                XInput = 0.60,
                XValues = new ReadOnlyCollection<double>([0.4, 0.5, 0.7, 0.8]),
                YValues = new double[]{-0.916291, -0.693147, -0.356675, -0.223144},
                ExpectedY = -0.509976
            },
        ];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}