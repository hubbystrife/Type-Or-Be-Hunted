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
        void Update()
        {
            foreach (KeyCode KeyInp in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(KeyInp))
                {
                    string key = KeyInp.ToString();
                    key = key.ToLower();
                    if (Target == null)
                    {
                        return;
                    }
                    else
                    {
                        if (key[0].Equals(Target.GetComponentInChildren<Canvas>().GetComponentInChildren<TMP_Text>().text[0]))
                        {
                            TMP_Text textTarget = this.Target.GetComponentInChildren<Canvas>().GetComponentInChildren<TMP_Text>();
                            
                            textTarget.color = Color.red;
                            
                            if (KadalManager.DieTarget(Target))
                            {
                                Target = null;
                            }
                        }
                        else
                        {
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
                Target = other.gameObject;
                kadalTxt = other.GetComponentInChildren<Canvas>().GetComponentInChildren<TMP_Text>().text;
            }
        }
    }
}

