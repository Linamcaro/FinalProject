using UnityEngine;

public class MouseInputPosition : MonoBehaviour
{
    //Detecta la posicion del mouse respecto a un objeto en una capa especifica

    [SerializeField] private Camera sceneCamera;
    [SerializeField] private LayerMask placementLayerMask;
    
    private Vector3 lastPosition;

    public Vector3 GetMousePositionInScene()
    {
        Ray ray = sceneCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 200f, placementLayerMask))
        {
            lastPosition = hit.point;
        }

        return lastPosition;
    }
}