using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("Destroy1");
    }

    IEnumerator Destroy1()
    {
        yield return new WaitForSeconds(33);
        Destroy(this.gameObject);
    }
}
