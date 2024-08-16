using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExitNumNotAnomaly : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance == null) return;
        tex.text = GameManager.Instance.CurrentNum.ToString();
    }
}
