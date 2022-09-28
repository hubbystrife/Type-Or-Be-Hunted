using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walksound : MonoBehaviour
{
    public static walksound instance;
    private AudioSource Audio;
	public AudioClip walk;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        Audio = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
        Audio.clip = walk;
        Audio.loop = true;
        
    }

    // Update is called once per frame
    public void Walk()
    {
        Audio.Play();
    }
    public void StopWalk()
    {
        Audio.Stop();
    }
}
