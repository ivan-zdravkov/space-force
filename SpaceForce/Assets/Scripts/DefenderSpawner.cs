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
            y: Input.mousePosition.y
        );

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(clickPosition);

        worldPosition.x = Mathf.RoundToInt(worldPosition.x);
        worldPosition.y = Mathf.RoundToInt(worldPosition.y);

        return worldPosition;
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
