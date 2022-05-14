using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boolGameobject : MonoBehaviour
{
	public GameObject gameobjkt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void OnCollisionEnter(/*Collision collision*/){
		//if(collision.gameObject.tag == "Player")
		gameobjkt.gameObject.SetActive(true);
	
		
	}
	// GameObject.Find("other_object_name").GetComponent(B).enabled = false;
	// GetComponent(B).enabled = false;
	
	/*
	 GameObject varGameObject = GameObject.Find("object");   or find with tag 
 
 GameObject varGameObject = GameObject.FindWithTag("Player"); then disable or enable script/component
 
 varGameObject.GetComponent<scriptname>().enabled = true;
example Js:

 var varGameObject = gameObject.Find("object")   Or with tag
 
 var varGameObject = gameObject.FindWithTag("player");
 
 varGameObject.GetComponent(scriptname).enabled = true;
	*/
}
