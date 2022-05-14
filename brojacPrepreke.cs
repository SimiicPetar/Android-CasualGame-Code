using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brojacPrepreke : MonoBehaviour
{
	public GameObject finish;
	static float yourNumberVariable = 0 ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(/*Collision collision*/){
		//if(collision.gameObject.tag == "Player")
		
	yourNumberVariable = yourNumberVariable + 1;
	if( yourNumberVariable == 2 ){
		finish.gameObject.SetActive(false);
	}
		
	}
}
