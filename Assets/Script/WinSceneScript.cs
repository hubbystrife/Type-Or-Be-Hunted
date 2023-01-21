using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinSceneScript : MonoBehaviour
{
    public Text TotalScore;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TotalScore.text = GameData.instance.Score.ToString();
    }

    public void backToMenu ()
    {
        SceneManager.LoadScene("2. GameMenu");
        GameData.instance.Destroyer();
    }
}
