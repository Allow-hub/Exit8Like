using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : Singleton<SEManager>
{
    public static SEManager Instance => I;
    public AudioSource se;
    [SerializeField] AudioClip clear,buttonClip;
    protected override void Init()
    {
        base.Init();
        DontDestroyOnLoad(gameObject);
        se = GetComponent<AudioSource>();
    }

    public void SetSEVolume(float volume)
    {
        se.volume = volume;
    }
    public void SuccessSe()
    {
        se.Stop();
        se.PlayOneShot(buttonClip);
    }

}
