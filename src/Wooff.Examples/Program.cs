using Wooff.ECS.Context;
using Wooff.Examples;
using Wooff.Examples.Components.CoreComponent;

var context = new EntityContext();
context.Add<TestEntity>();
context[typeof(TestEntity)][0].Add<Transform>(3f,4f,5f);
context
    .Get<TestEntity>()
        .Add<Obstacle, ObstacleData>(
        new ObstacleData() { Message = "Hello World"});


context.Update(1f);

