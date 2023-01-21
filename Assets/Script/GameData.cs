using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData instance;
    public float timerr;
    public bool onGoing = true;
    public bool lvl1isOver = false;
    public bool lvl2isOver = false;
    public bool lvl3isOver = false;
    public bool lvl4isOver = false;
    public bool lvl5isOver = false;
    public bool soundTuyul = true;
    public bool soundKunti = false;
    public bool soundBabi = false;
    public bool soundGenderuwo = false;
    public bool lvl2Hard = false;
    public bool lvl2easy = false;
    public bool lvl3Hard = false;
    public bool lvl3easy = false;
    public bool lvl4Hard = false;
    public bool lvl4easy = false;
    public bool lvl5Hard = false;
    public bool lvl5easy = false;
    public bool destroyCamera = false;
    public int EnemySpeed;
    public int Score = 0;
    public GameObject[] enemyy;


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

        DontDestroyOnLoad(gameObject);
    }


    void Update()
    {
        enemyy = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public void Destroyer()
    {
        Destroy(gameObject);
    }
}
