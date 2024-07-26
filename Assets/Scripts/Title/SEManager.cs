using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : Singleton<SEManager>
{
    public static SEManager Instance => I;
    public AudioSource se;
    [SerializeField] AudioClip clear,buttonClip,monotoneClip,screamClip;
    protected override void Init()
    {
        base.Init();
        DontDestroyOnLoad(gameObject);
        se = GetComponent<AudioSource>();
    }

    public void StopSe()
    {
        se.Stop();
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

    public void MonotoneSe()
    {
        se.Stop();
        se.PlayOneShot(monotoneClip);
    }

    public void ScreamSe()
    {
        se.Stop();
        se.PlayOneShot(screamClip);
    }
}
