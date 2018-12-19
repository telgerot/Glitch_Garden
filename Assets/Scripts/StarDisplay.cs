using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour {

    [SerializeField] public int stars = 100;
    [SerializeField] int maxStars = 999;
    Text starText;
    
    // Use this for initialization
	void Start () {
        starText = GetComponent<Text>();
        UpdateDisplay();
	}

    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }
	
    public void AddStars(int amount)
    {
        if (stars < maxStars)
        {
            stars += amount;
            if (stars > maxStars)
            {
                stars = maxStars;
            }
            UpdateDisplay();
        }

    }

    public void SubtractStars(int amount)
    {
        if (amount <= stars)
        {
            stars -= amount;
            UpdateDisplay();
        }
    }

    public int GetStars()
    {
        return stars;
    }

}
