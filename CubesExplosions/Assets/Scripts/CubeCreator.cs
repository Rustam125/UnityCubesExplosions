using UnityEngine;
using Random = UnityEngine.Random;

public class CubeCreator : MonoBehaviour
{
    public void Spawn(Cube cube)
    {
        var countOfCubes = GetRandomCount();
        
        cube.Destroy();

        if (cube.IsSplittable == false)
        {
            return;
        }
        
        for (var i = 0; i < countOfCubes; i++)
        {
            Create(cube);
        }
    }

    private void Create(Cube currentCube)
    {
        var cube = Instantiate(currentCube);
        cube.Init(currentCube.SplitChance);
    }
    
    private int GetRandomCount()
    {
        const int MinCount = 2;
        const int MaxCount = 6;

        return Random.Range(MinCount, MaxCount + 1);
    }
}
