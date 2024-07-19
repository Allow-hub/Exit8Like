using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyChasePlayer : AnomalyBase
{
    [SerializeField] private bool isClear = false;
    [SerializeField] private float distanceFromPlayer = 2f;
    [SerializeField] private GameObject player, anomaly;
    // Start is called before the first frame update
    void Start()
    {
        SetProperety();
    }

    // Update is called once per frame
    void Update()
    {
        Move();   
    }

    private void SetProperety()
    {
        IsClear = isClear;
        DistanceFromPlayer = distanceFromPlayer;
    }
    public override void Animation()
    {
        base.Animation();
        Move();
    }
    private void Move()
    {
        anomaly.transform.position=new Vector3(player.transform.position.x-1f,player.transform.position.y+0.5f,player.transform.position.z-0.5f);
    }

}
