using Wooff.ECS;
using Wooff.ECS.Component;

namespace Wooff.Examples.Components.CoreComponent;

public class Speaker : IComponent<SpeakerData>
{
    public string Message { get; set; } = string.Empty;

    public IInitable Init(params object[] data)
    {
        foreach (var obj in data)
        {
            if (obj is string message)
                Message += message;
            else
                throw new ArgumentException($"{obj} is not supported by the Speaker component, use string or SpeakerData instead!");
        }

        return this;
    }

    public IInitable<SpeakerData> Init(params SpeakerData[] data)
    {
        foreach (var obstacleData in data)
            Message = obstacleData.Message;

        return this;
    }

    public void Speak()
    {
        Console.WriteLine(Message);
    }
}

public class SpeakerData
{
    public string Message { get; set; }
}