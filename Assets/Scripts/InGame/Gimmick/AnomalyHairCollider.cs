using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyHairCollider : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private FadeManager fadeManager; 
    [SerializeField] private TurnBackCollider turnBackCollider;
    [SerializeField] private PlayerController playerController;

    [SerializeField] private GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if(other == null)return;
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(WaitFade());
            
        }
    }

    private IEnumerator WaitFade()
    {
        fadeManager.StartCoroutine(fadeManager.FadeIn(2f));
        yield return new WaitForSeconds(2f);
        turnBackCollider.TurnBackEvent();
        player.transform.position = playerController.startPos;
        GameManager.Instance.CurrentNum = 0;
    }
}
