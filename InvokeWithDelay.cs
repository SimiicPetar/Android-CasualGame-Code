using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeWithDelay : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public float delaySeconds;

    void Start()
    {
        StartCoroutine(EnablePlayermovement());
    }
    private IEnumerator EnablePlayermovement()
    {
        yield return new WaitForSeconds(delaySeconds);
        //playerMovement.enabled = true;
		//playerMovement.gameObject.SetActive(true);
    }
}