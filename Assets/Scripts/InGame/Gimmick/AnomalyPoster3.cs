using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyPoster3 : AnomalyBase
{
    [SerializeField]
    [Tooltip("target(right.left)")]
    private GameObject target;


    [SerializeField] private GameObject poster;
    [SerializeField] private GameObject anomalyPoster;
    [SerializeField] private GameObject blackEye;
    [SerializeField] private GameObject whiteEye;


    // Start is called before the first frame update
    void Start()
    {
        poster.SetActive(false);
        anomalyPoster.SetActive(true);
        blackEye.SetActive(true);
        whiteEye.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        PlayAnomaly(this.gameObject);

        Vector3 vector3 = target.transform.position - this.transform.position;
        vector3.y = 0f;

        Quaternion quaternion = Quaternion.LookRotation(vector3);
        this.transform.rotation = quaternion;
    }
}
