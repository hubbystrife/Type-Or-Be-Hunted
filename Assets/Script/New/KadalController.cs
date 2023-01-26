using Kadal.Word.Manager;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Kadal.Controller
{
    public class KadalController : MonoBehaviour
    {
        [SerializeField] private GameObject Target = null;
        [SerializeField] private string kadalTxt;
        public GameObject Penanda;
        void Update()
        {
            foreach (KeyCode KeyInp in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(KeyInp) & !Input.GetKey("up") & !Input.GetKey("down") & !Input.GetKey("left")& !Input.GetKey("right") & !Input.GetKey("mouse 0")& !Input.GetKey("mouse 1")& !Input.GetKey("space") & !Input.GetKey("left ctrl") & !Input.GetKey("right ctrl")& !Input.GetKey("right shift")& !Input.GetKey("left shift")& !Input.GetKey("tab")& !Input.GetKey("left alt")& !Input.GetKey("right alt")& !Input.GetKey("caps lock")& !Input.GetKey("`")& !Input.GetKey("1")& !Input.GetKey("2")& !Input.GetKey("3")& !Input.GetKey("4")& !Input.GetKey("5")& !Input.GetKey("6")& !Input.GetKey("7")& !Input.GetKey("8")& !Input.GetKey("9")& !Input.GetKey("0")& !Input.GetKey("-")& !Input.GetKey("=")& !Input.GetKey("enter")& !Input.GetKey("backspace"))
                {
                    string key = KeyInp.ToString();
                    key = key.ToLower();
                    if (Target == null)
                    {
                        Penanda.SetActive(false);
                        return;
                    }
                    else
                    {
                        if (key[0].Equals(Target.GetComponentInChildren<Canvas>().GetComponentInChildren<TMP_Text>().text[0]))
                        {
                            SoundManager.instance.Typing();
                            TMP_Text textTarget = this.Target.GetComponentInChildren<Canvas>().GetComponentInChildren<TMP_Text>();
                            
                            textTarget.color = Color.red;
                            
                            if (KadalManager.DieTarget(Target))
                            {
                                Penanda.SetActive(false);
                                Target = null;
                            }
                        }
                        else
                        {
                            SoundManager.instance.WrongAnswer();
                            TMP_Text textTarget = this.Target.GetComponentInChildren<Canvas>().GetComponentInChildren<TMP_Text>();
                            textTarget.color = Color.white;
                            textTarget.text = kadalTxt;
                        }
                    }
                }
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Penanda.SetActive(true);
                Target = other.gameObject;
                kadalTxt = other.GetComponentInChildren<Canvas>().GetComponentInChildren<TMP_Text>().text;
            }
        }
    }
}

