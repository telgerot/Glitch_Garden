using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    Defender defender;
    int defenderStarCost;

    private void OnMouseDown()// Executes spawn method using the location you got from GetSquareclicked
    {
        SpawnDefender(GetSquareClicked());
    }

    public void SetSelectedDefender(Defender defenderToSelect, int price)
    {
        defender = defenderToSelect;
        defenderStarCost = price;
    }

    private Vector2 GetSquareClicked() // looks where you are clicking the mouse, switching it to world point, then rounding it off so it fits in a grid square
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos; 
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos) // This is the "rounding process," taking mouse clicks and turning them into fixed intergers converting to world units
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 roundedPos) // Tries to spawn a defender, but checks to see if you have enough stars first (and issues a warning if you don't)
    {
        int currentStars = FindObjectOfType<StarDisplay>().GetStars();

        if (defenderStarCost <= currentStars)
        {
            Defender newDefender = Instantiate(defender, roundedPos, Quaternion.identity) as Defender;
            FindObjectOfType<StarDisplay>().SubtractStars(defenderStarCost);
        }
        else
        {
            FindObjectOfType<AnnouncementText>().WarningNotEnoughStars();
        }
    }

}
