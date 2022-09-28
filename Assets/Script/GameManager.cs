using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    [Header("Game Setting")]
    public float timer;
    public bool isOver;
    public int maxHealth = 100;
    public int currentHealth;
    
    

    [Header("UI")]
    public TextMeshProUGUI timerTxt;
    public HealthBar healthBar;
    public GameObject winCondition;
    public GameObject loseCondition;
    public TextMeshProUGUI scoreTxt;
    public int score;

    void Start()
    {
        timer = GameData.instance.timerr;
        isOver = false;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
    }


    void Update()
    {
        
        Debug.Log("musuh ada: " + GameData.instance.enemyy.Length);

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        if(GameData.instance.enemyy.Length == 0)
        {
            winCondition.SetActive(true);
            // script seluruh game jadi freeze atau terhenti
        }
        score = GameData.instance.Score;
        scoreTxt.text = score.ToString();
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
            float minutes = Mathf.FloorToInt(timer / 60);
            float seconds = Mathf.FloorToInt(timer % 60); // mod
            timerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        if (timer <= 0f && !isOver)
        {
            timerTxt.text = "00:00";
        }


        if (currentHealth == 0)
        {
            loseCondition.SetActive(true);
            isOver = true;
        }
    }
    

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    
}
