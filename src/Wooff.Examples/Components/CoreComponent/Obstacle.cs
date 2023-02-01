using Wooff.ECS;
using Wooff.ECS.Component;

namespace Wooff.Examples.Components.CoreComponent;

public class Obstacle : IComponent<ObstacleData>
{
    public string Message { get; set; }

    public void Update(float timeScale)
    {
        Console.WriteLine("Obstacle");
    }

    public IInitable Init(params object[] data)
    {
        foreach (var obj in data)
            if (obj is string message)
                Message += message;

        return this;
    }

    public IInitable<ObstacleData> Init(params ObstacleData[] data)
    {
        foreach (var obstacleData in data)
            Message = obstacleData.Message;

        return this;
    }
}

public class ObstacleData
{
    public string Message { get; set; }
}