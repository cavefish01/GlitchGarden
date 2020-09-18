using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Lives : MonoBehaviour
{
    [SerializeField] float baseLives = 3f;
    [SerializeField] int damage = 1;

    float lives;
    Text livesText;

    // Start is called before the first frame update
    void Start()
    {
        lives = baseLives - PlayerPrefsController.GetDifficulty();

        livesText = GetComponent<Text>();
        UpdateLives();


        Debug.Log("difficulty = " + PlayerPrefsController.GetDifficulty());
    }

    private void UpdateLives()
    {
        livesText.text = lives.ToString();
    }

    public void SubtractLives()
    {
        lives -= damage;
        UpdateLives();

        if(lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
