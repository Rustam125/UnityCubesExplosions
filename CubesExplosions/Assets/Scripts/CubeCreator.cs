using UnityEngine;
using Random = UnityEngine.Random;

public class CubeCreator : MonoBehaviour
{
    public static void Spawn(Cube cube)
    {
        var countOfCubes = GetRandomCount();
        
        cube.Destroy();

        if (!cube.IsSplittable)
        {
            return;
        }
        
        for (var i = 0; i < countOfCubes; i++)
        {
            Create(cube);
        }
    }

    private static void Create(Cube currentCube)
    {
        var cube = Instantiate(currentCube);
        cube.Init(currentCube.SplitChance);
    }
    
    private static int GetRandomCount()
    {
        const int minCount = 2;
        const int maxCount = 6;

        return Random.Range(minCount, maxCount + 1);
    }
}
