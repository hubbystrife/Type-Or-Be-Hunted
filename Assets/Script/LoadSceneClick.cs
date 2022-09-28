using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneClick : MonoBehaviour
{

    [Header("Main Settings")]
    public string TargetScene;

    public void LoadScene()
    {
        //Melakukan perpindahan antar scene. Catatan: Scene yang dipanggil sudah didaftarkan di Build Setting
        SceneManager.LoadScene("Video");
    }
    public void Ulang()
    {
        //Melakukan perpindahan antar scene. Catatan: Scene yang dipanggil sudah didaftarkan di Build Setting
        SceneManager.LoadScene("3. GamePlay");
        GameData.instance.Score = 0;
        
    }
    public void Menu()
    {
        //Melakukan perpindahan antar scene. Catatan: Scene yang dipanggil sudah didaftarkan di Build Setting
        SceneManager.LoadScene("2. GameMenu");
        GameData.instance.Score = 0;
        
    }
    

    public void exit()
    {
        Application.Quit();
    }

    
}