using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : Singleton<BGMManager>
{
    public static BGMManager Instance => I;

    public AudioSource titleBGM;
    protected override void Init()
    {
        base.Init();
        DontDestroyOnLoad(gameObject);
        if (titleBGM == null) return;
        titleBGM.Play();
    }


    public void StopBGM()
    {
        if (titleBGM == null) return;

        titleBGM.Stop();
    }
    public void TitleBGM()
    {
        if (titleBGM == null) return;

        titleBGM.Play();
    }
    public void SetBGMVolume(float volume)
    {
        titleBGM.volume = volume;
    }
}
