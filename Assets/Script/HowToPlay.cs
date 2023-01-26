using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour
{
    public GameObject HTP1 ;
    public GameObject HTP2 ; 
    public GameObject HTP3 ; 
    public GameObject HTP4 ; 

    public void btnNextHTP1(){
        HTP1.SetActive(false);
    }
    public void btnNextHTP2(){
        HTP2.SetActive(false);
    }
    public void btnBackHTP2(){
        HTP1.SetActive(true);
    }
    public void btnNextHTP3(){
        HTP3.SetActive(false);
    }
    public void btnBackHTP3(){
        HTP2.SetActive(true);
    }
    public void btnPlay(){
        SceneManager.LoadScene("3. GamePlay");
    }
    public void btnBackHTP4(){
        HTP3.SetActive(true);
    }
}
