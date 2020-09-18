using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;
    Text starText;
    private void Start()
    {
        starText = GetComponent<Text>();
        UpdateStars();
    }

    private void UpdateStars()
    {
        starText.text = stars.ToString();
    }

    public void AddStars(int amount)
    {
        stars += amount;
        UpdateStars();
    }

    public void SubtractStars(int amount)
    {
        if (stars < amount)
        {
            return; //place where to put an error to the user 
        }
        else
        {
            stars -= amount;
            UpdateStars();
        }

    }

    public bool HaveEnoughStars(int amount)
    {
        return stars >= amount;
    }
}
