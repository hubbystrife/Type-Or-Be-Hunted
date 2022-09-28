using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DelayPlay");
    }

    IEnumerator DelayPlay()
    {
        yield return new WaitForSeconds(33);
        SceneManager.LoadScene("3. GamePlay");
    }

    public void SkipBtn()
    {
        SceneManager.LoadScene("3. GamePlay");
    }


}
