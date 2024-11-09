using UnityEngine;
using Random = UnityEngine.Random;

public class CubeCreator : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    
    private void Awake()
    {
        _cube.Split += OnCubeSplit;
    }

    private void OnCubeSplit(Cube cube)
    {
        for (var i = 0; i < GetRandomCount(); i++)
        {
            Create(cube);
        }
    }

    private void Create(Cube cube)
    {
        var newCube = Instantiate(cube);
        newCube.Init(cube.SplitChance);
        newCube.Split += OnCubeSplit;
    }
    
    private static int GetRandomCount()
    {
        const int minCount = 2;
        const int maxCount = 6;

        return Random.Range(minCount, maxCount + 1);
    }
}
