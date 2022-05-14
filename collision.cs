using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collision : MonoBehaviour
{
	
    void OnCollisionEnter(/*Collision collision*/){
		//if(collision.gameObject.tag == "Player")
		
			Destroy(gameObject);
		
		
	}
	/*void OnMouseEnter( Collision collision ){
		//if(collision.gameObject.tag == "Player")
		//Destroy(gameObject);
		
	} */
}
