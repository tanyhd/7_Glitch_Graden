using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendersSpawner : MonoBehaviour
{
    Defender defender;

    private void OnMouseDown()
    {
        SpawnDefender(GetSquareClicked());
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void SpawnDefender(Vector2 roundedPos)
    {
        if (defender == null) { return; }
        Defender newDefender = Instantiate(defender, roundedPos, Quaternion.identity) as Defender;
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWroldPos)
    {
        float newX = Mathf.RoundToInt(rawWroldPos.x);
        float newY = Mathf.RoundToInt(rawWroldPos.y);
        return  new Vector2(newX,newY);
    }
}
