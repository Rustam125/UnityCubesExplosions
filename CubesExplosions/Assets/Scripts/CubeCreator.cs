using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CubeCreator : MonoBehaviour
{
    [CanBeNull]
    public static List<Cube> Spawn(Cube cube)
    {
        var cubes = new List<Cube>();
        var countOfCubes = GetRandomCount();
        
        cube.Destroy();

        if (!cube.IsSplittable)
        {
            return null;
        }
        
        for (var i = 0; i < countOfCubes; i++)
        {
            cubes.Add(Create(cube));
        }

        return cubes;
    }

    private static Cube Create(Cube currentCube)
    {
        var cube = Instantiate(currentCube);
        cube.Init(currentCube.SplitChance);
        return cube;
    }
    
    private static int GetRandomCount()
    {
        const int minCount = 2;
        const int maxCount = 6;

        return Random.Range(minCount, maxCount + 1);
    }
}
