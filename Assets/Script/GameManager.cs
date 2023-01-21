using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.SceneManagement;

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
    public TextMeshProUGUI scoreTxt;
    private int scoreBonus;
    public int score;

    [Header("GameObject")]
    public GameObject[] players;
    public GameObject player;
    public GameObject[] MCs;
    public GameObject MC;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

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
            if(GameData.instance.lvl1isOver == true )
            {
                if(GameData.instance.lvl2isOver == true )
                {
                    if(GameData.instance.lvl3isOver == true )
                    {
                        if(GameData.instance.lvl4isOver == true )
                        {
                            MCs = GameObject.FindGameObjectsWithTag("Camera");
                            MC = MCs[0];
                            players = GameObject.FindGameObjectsWithTag("Player");
                            player = players[0];
                            Destroy(MC);
                            Destroy(player);
                            scoreBonus = (int) timer * 100;
                            score += scoreBonus;
                            GameData.instance.Score += score ;
                            GameData.instance.destroyCamera = true;
                            SceneManager.LoadScene("Win Scene"); 
                            
                            
                            
                        }
                        else {
                            scoreBonus = (int) timer * 100;
                            score += scoreBonus;
                            GameData.instance.Score += score ;
                            GameData.instance.lvl4isOver = true;
                            GameData.instance.soundGenderuwo = true;
                            GameData.instance.soundKunti = false;
                            if (GameData.instance.Score > 200000)
                            {
                                GameData.instance.lvl5Hard = true;
                            }
                            else {
                                GameData.instance.lvl5easy = true;
                            }
                            SceneManager.LoadScene("7. Level5");
                        }
                    
                    }
                    else{
                        scoreBonus = (int) timer * 100;
                        score += scoreBonus;
                        GameData.instance.Score += score ;
                        GameData.instance.lvl3isOver = true;
                        GameData.instance.soundKunti = true;
                        GameData.instance.soundBabi = false;
                        if (GameData.instance.Score > 150000)
                        {
                            GameData.instance.lvl4Hard = true;
                        }
                        else {
                            GameData.instance.lvl4easy = true;
                        }
                        SceneManager.LoadScene("6. Level4");
                    }
                    
                }
                else{
                    scoreBonus = (int) timer * 100;
                    score += scoreBonus;
                    GameData.instance.Score += score ;
                    GameData.instance.lvl2isOver = true;
                    GameData.instance.soundBabi = true;
                    GameData.instance.soundTuyul = false;
                    if (GameData.instance.Score > 100000)
                    {
                        GameData.instance.lvl3Hard = true;
                    }
                    else {
                        GameData.instance.lvl3easy = true;
                    }
                    SceneManager.LoadScene("5. Level3");
                }
                
            }
            else {
                scoreBonus = (int) timer * 100;
                score += scoreBonus;
                GameData.instance.Score += score ;
                GameData.instance.lvl1isOver = true;
                if (GameData.instance.Score > 50000)
                {
                    GameData.instance.lvl2Hard = true;
                }
                else {
                    GameData.instance.lvl2easy = true;
                }
                SceneManager.LoadScene("4. Level2");
                
            }
        }
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
            SceneManager.LoadScene("Lose Scene");
            isOver = true;
        }

        if (currentHealth == 0)
        {
            SceneManager.LoadScene("Lose Scene");
            isOver = true;
        }
    }
    

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    
}
