using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        Vector2Int gridPos = waypoint.GetGridPos();
        transform.position = new Vector3(
            gridPos.x * gridSize,
            0f,
            gridPos.y * gridSize
            );
    }

    private void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        Vector2Int gridPos = waypoint.GetGridPos();
        string labelText = gridPos.x + "," + gridPos.y;
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}