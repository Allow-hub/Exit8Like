using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class AnomalyPoster3 : AnomalyBase
{
    [SerializeField] private GameObject poster;
    [SerializeField] private GameObject anomalyPoster;
    [SerializeField] private GameObject blackEye;
    [SerializeField] private GameObject whiteEye;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject RightEyeParts1;
    [SerializeField] private GameObject RightEyeParts2;
    [SerializeField] private GameObject LeftEyeParts1;
    [SerializeField] private GameObject LeftEyeParts2;

    Vector3 RightEyePos1;
    Vector3 RightEyePos2;
    Vector3 LeftEyePos1;
    Vector3 LeftEyePos2;

    public Transform player;
    public float moveSpeed = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        // ‰æ‘œ‚Ì•\Ž¦/”ñ•\Ž¦
        poster.SetActive(false);
        anomalyPoster.SetActive(true);
        blackEye.SetActive(true);
        whiteEye.SetActive(true);

        RightEyePos1 = RightEyeParts1.transform.position;
        RightEyePos2 = RightEyeParts2.transform.position;
        LeftEyePos1 = LeftEyeParts1.transform.position;
        LeftEyePos2 = LeftEyeParts2.transform.position;

 
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        
    
    }
}
