using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject Pause_Btn;

    public void openPauseMenu()
    {
        Pause_Btn.SetActive(true);
        Time.timeScale = 0;
    }
    public void closePauseMenu()
    {
        Pause_Btn.SetActive(false);
        Time.timeScale = 1;
    }
}
