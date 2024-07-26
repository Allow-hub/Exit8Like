using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExitNum : MonoBehaviour
{
    private int lastNum;
    [SerializeField] private TextMeshProUGUI tex;
    [SerializeField] ExitTextAnomaly textAnomaly;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance == null) return;    
        lastNum = GameManager.Instance.CurrentNum;
        tex.text = lastNum.ToString();
    }

    // Update is called once per frame
    void Update()
    { 
        if (GameManager.Instance == null) return;    
        if(lastNum != GameManager.Instance.CurrentNum)
        {
            lastNum = GameManager.Instance.CurrentNum;
            tex.text = lastNum.ToString();
        }
    }
}
