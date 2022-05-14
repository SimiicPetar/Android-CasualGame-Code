using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script colaborates to the tutorial
//https://www.youtube.com/watch?v=pK1CbnE2VsI

public class Bear : MonoBehaviour {

    float distance = 10;

    private void OnMouseDrag()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0 /*distance*/);
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
		Debug.Log("helo");

        transform.position = objectPos;
    }
}