using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] private GameObject mouseIndicatorPosition;
    [SerializeField] private Material indicatorMaterial;
    [SerializeField] private MouseInputPosition mouseInputPositionScript;
    [SerializeField] private Grid grid;
    [SerializeField] private TowerPoolSystem towerQueueScript;

    private HashSet<Vector3Int> filledCells = new HashSet<Vector3Int>();

    void Update()
    {
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.Playing)
        {
            Vector3 mousePosition = mouseInputPositionScript.GetMousePositionInScene();

            Vector3Int gridPosition = grid.WorldToCell(mousePosition);

            mouseIndicatorPosition.transform.position = grid.CellToWorld(gridPosition);

            if (filledCells.Contains(gridPosition))
            {
                indicatorMaterial.color = Color.red;
            }
            else
            {
                indicatorMaterial.color = Color.green;
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (!filledCells.Contains(gridPosition))
                {
                    GameObject nextTower = towerQueueScript.GetNextTower();

                    towerQueueScript.UpdateQueueUI();

                    if (nextTower != null)
                    {
                        Instantiate(nextTower, grid.CellToWorld(gridPosition), Quaternion.identity);

                        filledCells.Add(gridPosition);
                    }
                }
            }
        }
    }
}