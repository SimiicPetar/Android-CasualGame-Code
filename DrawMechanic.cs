using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMechanic : MonoBehaviour
{

    //SPAWM OBJECTS
    public GameObject DrawPrefab;
    private GameObject Ketchup;
    public float DistanceFloat;

    //DRAG WITH MOUSE
    private Vector3 screenPoint;
    public Vector3 offset;

    void OnMouseDown()
    {
        //DRAG WITH MOUSE
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    void OnMouseDrag()
    {
        //DRAG WITH MOUSE
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;

        // TRANSPORT - FOLLOW MOUSE CURSOR 
        Vector3 newPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(Camera.main.transform.position.z - transform.position.z)));
        newPos.z = transform.position.z;
        transform.position = newPos;

        //SPAWN WHILE DRAGING
        GameObject Ketchup = Instantiate(DrawPrefab) as GameObject;
        Ketchup.transform.position = transform.position + Camera.main.transform.forward * DistanceFloat;
    }
}