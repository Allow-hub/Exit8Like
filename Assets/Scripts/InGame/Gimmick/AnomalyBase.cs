using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyBase : MonoBehaviour
{
    public bool IsClear {  get; set; }
    public float DistanceFromPlayer { get; set; } //異変を起こすプレイヤーとの距離

    public virtual void PlayAnomaly(GameObject obj)
    {
        
    }
}
