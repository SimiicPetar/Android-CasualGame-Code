using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetProzor : MonoBehaviour
{
    public GameObject reset;
	 public GameObject offObject;
	 float yourNumberVariable = 0 ;
    // Start is called before the first frame update
    void Start()
    {
        
	}
    
	void Update()
{
        if( yourNumberVariable == 4 ){
		reset.gameObject.SetActive(true);
		offObject.gameObject.SetActive(false);
    }
    
}
public void loseButton(/*Collision collision*/){
		//if(collision.gameObject.tag == "Player")
		
	yourNumberVariable = yourNumberVariable + 1;
	
		
	}
	}

