using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip tuyuldead;
    public AudioClip tuyulspawn;
    public AudioClip kuntidead;
    public AudioClip kuntispawn;
    public AudioClip babidead;
    public AudioClip babispawn;
    public AudioClip genderuwodead;
    public AudioClip genderuwospawn;
    public AudioClip typing;
    public AudioClip hit;
    public AudioClip soundWrong;

    private AudioSource audio;

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
        audio = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
    }

    public void TuyulSpawn()
    {
        audio.PlayOneShot(tuyulspawn);
    }

    public void TuyulDead()
    {
        audio.PlayOneShot(tuyuldead);
    }

    public void KuntiSpawn()
    {
        audio.PlayOneShot(kuntispawn);
    }

    public void KuntiDead()
    {
        audio.PlayOneShot(kuntidead);
    }

    public void GenderuwoSpawn()
    {
        audio.PlayOneShot(genderuwospawn);
    }

    public void GenderuwoDead()
    {
        audio.PlayOneShot(genderuwodead);
    }

    public void BabiSpawn()
    {
        audio.PlayOneShot(babispawn);
    }

    public void BabiDead()
    {
        audio.PlayOneShot(babidead);
    }

    public void Typing()
    {
        audio.PlayOneShot(typing);
    }

    public void Hit()
    {
        audio.PlayOneShot(hit);
    }
    public void WrongAnswer()
    {
        audio.PlayOneShot(soundWrong);
    }

    


}
