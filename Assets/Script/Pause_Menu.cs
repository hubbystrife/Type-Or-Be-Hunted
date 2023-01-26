using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Pause_Menu : MonoBehaviour
{
    public TextMeshProUGUI timerTxt;
    public HealthBar healthBar;
    public TextMeshProUGUI scoreTxt;
    public int score;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = GameManager.instance.scoreTxt.text;
        timerTxt.text = GameManager.instance.timerTxt.text;
        healthBar.SetHealth(GameManager.instance.currentHealth);
    }
}
