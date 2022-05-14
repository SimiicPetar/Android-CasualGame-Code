using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class brojacVoce : MonoBehaviour
{
    
	/*public GameObject a1;
	public GameObject a2;
	public GameObject a3;
	public GameObject a4;
	public GameObject a5;
	public GameObject a6;
	public GameObject a7;
	public GameObject a8;
	public GameObject a9;
	public GameObject a10;
	public GameObject b1;
	public GameObject b2;
	public GameObject b3;
	public GameObject b4;
	public GameObject b5;
	public GameObject b6;
	public GameObject b7;
	public GameObject b8;
	public GameObject b9;
	public GameObject b10;
	public GameObject c1;
	public GameObject c2;
	public GameObject c3;
	public GameObject c4;
	public GameObject c5;
	public GameObject c6;
	public GameObject c7;
	public GameObject c8;
	public GameObject c9;
	public GameObject c10;*/
	public Text txt;
	static float yourNumberVariable = 0 ;
	//private float asd = 0;
	
	
	
    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
	
    {
		
      /* if (a1 == null ){ yourNumberVariable = yourNumberVariable + 1; }             
		//if (a2 == null ){  yourNumberVariable = yourNumberVariable + 1; }  
		if (a3 == null ){ yourNumberVariable = yourNumberVariable + 1; } 
		if (a4 == null ){   yourNumberVariable = yourNumberVariable + 1; }               
		if (a5 == null ){   yourNumberVariable = yourNumberVariable + 1; } 
		if (a6 == null ){  yourNumberVariable = yourNumberVariable + 1; } 
		if (a7 == null ){    yourNumberVariable = yourNumberVariable + 1; }              
		if (a8 == null ){   yourNumberVariable = yourNumberVariable + 1; } 
		if (a9 == null ){  yourNumberVariable = yourNumberVariable + 1; } 
		if (a10 == null){ yourNumberVariable = yourNumberVariable + 1; } 
		if (b1 == null ){  yourNumberVariable = yourNumberVariable + 1; }                
		if (b2 == null ){  yourNumberVariable = yourNumberVariable + 1; }  
		if (b3 == null ){ yourNumberVariable = yourNumberVariable + 1; } 
		if (b4 == null ){  yourNumberVariable = yourNumberVariable + 1; }                
		if (b5 == null ){   yourNumberVariable = yourNumberVariable + 1; } 
		if (b6 == null ){  yourNumberVariable = yourNumberVariable + 1; } 
		if (b7 == null ){   yourNumberVariable = yourNumberVariable + 1; }               
		if (b8 == null ){   yourNumberVariable = yourNumberVariable + 1; } 
		if (b9 == null ){  yourNumberVariable = yourNumberVariable + 1; } 
		if (b10 == null){ yourNumberVariable = yourNumberVariable + 1; } 
if (c1 == null ){      yourNumberVariable = yourNumberVariable + 1; }            
		if (c2 == null ){ yourNumberVariable = yourNumberVariable + 1; }   
		if (c3 == null ){ yourNumberVariable = yourNumberVariable + 1; } 
		if (c4 == null ){  yourNumberVariable = yourNumberVariable + 1; }                
		if (c5 == null ){   yourNumberVariable = yourNumberVariable + 1; } 
		if (c6 == null ){  yourNumberVariable = yourNumberVariable + 1; } 
		if (c7 == null ){  yourNumberVariable = yourNumberVariable + 1; }                
		if (c8 == null ){   yourNumberVariable = yourNumberVariable + 1; } 
		if (c9 == null ){  yourNumberVariable = yourNumberVariable + 1; } 
		if (c10 == null){	 yourNumberVariable = yourNumberVariable + 1; } 
//plane.gameObject.SetActive(true);
//touchLose.gameObject.SetActive(false);

		
		/*}}}}}}}}}}
		}}}}}}}}}}
		}}}}}}}}}}*/
		
    }
	void OnCollisionEnter(/*Collision collision*/){
		//if(collision.gameObject.tag == "Player")
		txt.text = yourNumberVariable.ToString();
	yourNumberVariable = yourNumberVariable + 1;
		
	}
	
}
/*
txt.text = yourNumberVariable.ToString();
    }
	public void OnMouseDown(){
		yourNumberVariable = yourNumberVariable + 1;
	}
*/
