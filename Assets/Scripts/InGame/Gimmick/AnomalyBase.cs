using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyBase : MonoBehaviour
{
    public bool IsClear {  get; set; }
    public float DistanceFromPlayer { get; set; } //異変を起こすプレイヤーとの距離
    public  SpriteRenderer spriteRenderer;

    public  void PlayAnomaly(GameObject obj)
    {
        if (GameManager.Instance == null) return;
       float distance = Vector3.Distance(obj.transform.position, GameManager.Instance.player.transform.position);
        Debug.Log(distance);
        if (distance <= DistanceFromPlayer)
        {
            Animation();
        }
    }

    public virtual void Animation() 
    {

    }
    public virtual void ReverseAnomaly()
    {

    }
}
