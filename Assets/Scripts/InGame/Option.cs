using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    [SerializeField] private GameObject optionCanvas,option,anomaly,explain;
    [SerializeField] private Button optionButton,anomalyButton , explainButton; 

    private void Awake()
    {
        optionCanvas.SetActive(false);
        optionButton.onClick.AddListener(() => Active(false, true, false));
        anomalyButton.onClick.AddListener(() => Active(false, false, true));
        explainButton.onClick.AddListener(() => Active(true, false, false));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(optionCanvas.activeSelf)
            {
                optionCanvas.SetActive(false);
            }
            else
            {
                optionCanvas.SetActive(true);
            }
        }
            
    }

    private void OnEnable()
    {
        explain.gameObject.SetActive(true);
        option.gameObject.SetActive(false);
        anomaly.gameObject.SetActive(false);
    }

    private void Active(bool ex,bool op ,bool an)
    {
        explain.gameObject.SetActive(ex);
        option.gameObject.SetActive(op);
        anomaly.gameObject.SetActive(an);
    }

    public   void ActiveCanvas()
    {
        optionCanvas.SetActive(true);
    }
}
