using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseHTP : MonoBehaviour
{
    public GameObject HTP;

    public void Closehtp()
    {
        HTP.SetActive(false);
    }
}
