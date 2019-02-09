using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] int lives = 5;
    Text livesText;
    [SerializeField] int damage = 1;

    LevelLoader levelLoader;

    // Start is called before the first frame update
    void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
        livesText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        livesText.text = lives.ToString();
    }


    public void TakeLife()
    {
        lives -= damage;
        UpdateDisplay();
        if (lives <= 0)
        {
            levelLoader.LoadLoseScene();
        }
    }
}
