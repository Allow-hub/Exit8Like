using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyBase : MonoBehaviour
{
    public bool IsClear {  get; set; }
    public bool IsAnomaly { get; set; }//異変が起きているか
    public float DistanceFromPlayer { get; set; } //異変を起こすプレイヤーとの距離
    public  SpriteRenderer spriteRenderer;

    public int Number { get; set; }
    public string Explain { get; set; }
    public  void PlayAnomaly(GameObject obj)
    {
        if (GameManager.Instance == null) return;
        if (!IsAnomaly) return;
        float distance = Vector3.Distance(obj.transform.position, GameManager.Instance.player.transform.position);
       
        if (distance <= DistanceFromPlayer)
        {
            Animation();
        }
    }

    public virtual void Animation() 
    {
        IsAnomaly = true;
    }
    public virtual void ReverseAnomaly()
    {
        IsAnomaly=false;
    }
}
