using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collisionActive : MonoBehaviour
{
	public GameObject active;
    void OnCollisionEnter(/*Collision collision*/){
		//if(collision.gameObject.tag == "Player")
		
			if( active != null ){
		
			active.gameObject.SetActive(true);
		}
		
	}
	/*void OnMouseEnter( Collision collision ){
		//if(collision.gameObject.tag == "Player")
		//Destroy(gameObject);
		
	} */
}
