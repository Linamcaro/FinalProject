using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] private GameObject mouseIndicatorPosition;
    [SerializeField] private MouseInputPosition mouseInputPositionScript;
    [SerializeField] private Grid grid;

    void Update()
    {
        Vector3 mousePosition = mouseInputPositionScript.GetMousePositionInScene();

        Vector3Int gridPosition = grid.WorldToCell(mousePosition);

        mouseIndicatorPosition.transform.position = grid.CellToWorld(gridPosition);
    }
}