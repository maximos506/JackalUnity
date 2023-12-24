using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    AudioSource audiosource;
    public AudioClip MoveClip,CollectMoney,LoseMoney,GetBeaten;
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }
    public void GetMoney()
    {
        audiosource.clip = CollectMoney;
        audiosource.Play();
    }
    public void BeatSound()
    {
        audiosource.clip = GetBeaten;
        audiosource.Play();
    }
    public void DropMoney()
    {
        audiosource.clip = LoseMoney;
        audiosource.Play();
    }
    public void PlayMoveSound()
    {
        audiosource.clip = MoveClip;
        audiosource.Play();
    }
    void Update()
    {
        
    }
}
