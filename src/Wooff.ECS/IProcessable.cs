namespace Wooff.ECS
{
    public interface IProcessable 
    {
        public void Process(float timeScale);
    }

    public interface IProcessable<in T> 
    {
        public void Process(float timeScale, T data);
    }
}