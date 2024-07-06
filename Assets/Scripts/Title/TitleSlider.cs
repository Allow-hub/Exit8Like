using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSlider : MonoBehaviour
{
    public void SetBGMVolume(float volume)
    {
        BGMManager.Instance.SetBGMVolume(volume);
    }
    public void SetSEVolume(float volume)
    {
        SEManager.Instance.SetSEVolume(volume);
    }
}
