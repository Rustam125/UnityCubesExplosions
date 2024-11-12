using JetBrains.Annotations;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private const int LeftMouseButton = 0;
    
    [CanBeNull] private CubeCreator _cubeCreator;

    private void Awake()
    {
        var cubeCreatorObject = GameObject.Find("CubeCreator");
        _cubeCreator = cubeCreatorObject?.GetComponent<CubeCreator>();
    }

    private void Update()
    {
        ClickOnCubeHandle();
    }

    private void ClickOnCubeHandle()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton) == false)
        {
            return;
        }

        var ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out var hit) ||
            !hit.transform.TryGetComponent(out Cube cube))
        {
            return;
        }
        
        var cubeExploser = new CubeExploser(cube);
        cubeExploser.Explode();

        if (_cubeCreator)
        {
            _cubeCreator.Spawn(cube);
        }
    }
}
