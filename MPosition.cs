using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MPosition : MonoBehaviour
{
    public GameObject pointer;
    public bool isPressed;

    private void Start()
    {
        pointer.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isPressed = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isPressed = false;
        }
        if (isPressed)
        {
            pointer.gameObject.SetActive(true);
            pointer.gameObject.transform.position = Input.mousePosition;
        }else if (!isPressed)
        {
            pointer.gameObject.SetActive(false);
        }
    }
}
