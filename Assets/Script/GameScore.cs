using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    public float currScore = 0;

    [SerializeField] Text scoreValue;

    private void Start()
    {
        currScore = 0;
    }

    public void AddScore(float Scrvalue)
    {
        currScore += Scrvalue;
    }

    private void UpdateScoreUI()
    {
        scoreValue.text = currScore.ToString("0");
    }
}
