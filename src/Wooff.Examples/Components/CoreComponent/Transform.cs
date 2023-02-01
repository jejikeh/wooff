using Wooff.ECS;
using Wooff.ECS.Component;

namespace Wooff.Examples.Components.CoreComponent;

public class Transform : IComponent
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }

    public void Update(float timeScale)
    {
        Console.WriteLine("Transform");
    }

    public IInitable Init(params object[] data)
    {
        X = (float)data[0];
        Y = (float)data[1];
        Z = (float)data[2];

        return this;
    }
}