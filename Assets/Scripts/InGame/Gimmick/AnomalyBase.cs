using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyBase : MonoBehaviour
{
    public bool IsClear {  get; set; }
    public float DistanceFromPlayer { get; set; } //�ٕς��N�����v���C���[�Ƃ̋���

    public virtual void PlayAnomaly(GameObject obj)
    {
        
    }
}
