using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animator : MonoBehaviour
{
	
   
 
  public Animator knop;
 
  // Start is called before the first frame update
  void Start()
  {
 
  }
 
  // Update is called once per frame
  void Update()
  {
     /* if(Input.GetKeyDown(KeyCode.Space))
     {
         knop.SetBool("Bool", true);
     }
     if(Input.GetKey(KeyCode.Space))
     {
         knop.SetBool("Bool", true);
     }
     if(Input.GetKeyUp(KeyCode.Space))
     {
         knop.SetBool("Bool", false);
     }*/
	  if (Input.GetMouseButtonUp(0))
        {
			if( knop != null){
				knop.SetBool("Bool", false);
			}
          
          
          
          
        }
		/*if (Input.GetMouseButton(0))
        { 
			knop.SetBool("Bool", true);
		}*/
		/*void OnMouseEnter(/*Collision collision ){
		//if(collision.gameObject.tag == "Player")
		
		
            if (Input.GetMouseButton(0))
        {
			knop.SetBool("Bool", true);
			
			}
			} */
	
	
		
		
  }
    void OnMouseDown(/*Collision collision */){
		//if(collision.gameObject.tag == "Player")
		
		if( knop != null){
				knop.SetBool("Bool", true);
			}
            
			
	
		
		}
		}
        

