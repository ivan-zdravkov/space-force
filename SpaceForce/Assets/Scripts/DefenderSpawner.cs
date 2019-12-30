using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] GameObject defender;

    private void OnMouseDown()
    {
        Vector3 position = this.GetSquareClicked();

        this.SpawnDefender(position);
    }

    private Vector3 GetSquareClicked()
    {
        Vector3 clickPosition = new Vector3(
            x: Input.mousePosition.x,
            y: Input.mousePosition.y,
            z: 0
        );

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(clickPosition);
        Vector3 gridPosition = this.SnapToGrid(worldPosition);

        return gridPosition;
    }

    private Vector3 SnapToGrid(Vector3 position)
    {
        position.x = Mathf.RoundToInt(position.x);
        position.y = Mathf.RoundToInt(position.y);
        position.z = 0;

        return position;
    }

    private void SpawnDefender(Vector3 position)
    {
        GameObject defender = Instantiate(
            original: this.defender,
            position: position,
            rotation: Quaternion.Euler(new Vector3(0, 0, 270))
        ) as GameObject;
    }
}
