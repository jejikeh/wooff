using System.Diagnostics;
using Wooff.Examples.Entities;
using Wooff.Examples.Worlds;



var res = 0f;
for (var k = 0; k < 10; k++)
{
    var park = new Park();
    for (var i = 0; i < 1000000; i++)
        park.EntityContext.Add<Dog>();

    var st = new Stopwatch();

    st.Start();
    await park.UpdateParallelAsync(1f);
    // park.Update(1f);
    
    st.Stop();

    res += (float)(st.ElapsedMilliseconds) / 1000;
    Console.WriteLine($"{res / k} esalped second for {k} number");
}

Console.WriteLine($"\n\n\n{res} elapsed seconds");
Console.WriteLine($"{res / 10} average");

// UPDATE()
// 674,41907 elapsed seconds
// 67,44191 average

// UPDATEPARALLELASYNC no chunks
// 728,588 elapsed seconds
// 72,8588 average

// UPDATEPARALLELASYNC chunks
// 821,43896 elapsed seconds
// 82,1439 average


