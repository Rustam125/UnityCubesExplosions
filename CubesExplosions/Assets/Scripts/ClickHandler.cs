using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private void Update()
    {
        ClickOnCubeHandle();
    }

    private void ClickOnCubeHandle()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        var ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out var hit) ||
            !hit.transform.TryGetComponent(out Cube cube))
        {
            return;
        }

        CubeCreator.Spawn(cube);
        CubeExploser.Explode(cube);
    }
}
