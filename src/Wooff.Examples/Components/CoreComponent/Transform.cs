using Wooff.ECS;
using Wooff.ECS.Component;

namespace Wooff.Examples.Components.CoreComponent;

public class Transform : IComponent<float>
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }

    public Transform()
    {
        
    }

    public Transform(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public IInitable Init(params object[] data)
    {
        X = (float)data[0];
        Y = (float)data[1];
        Z = (float)data[2];

        return this;
    }

    public IInitable<float> Init(params float[] data)
    {
        X = data[0];
        Y = data[1];
        Z = data[2];

        return this;
    }
}