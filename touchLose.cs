using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchLose : MonoBehaviour
{
	public GameObject canvas;
	public GameObject zvezda;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void OnMouseEnter(/*Collision collision */){
		//if(collision.gameObject.tag == "Player")
		
		if (Input.GetMouseButton(0))
        {
            //Destroy(gameObject);
			//canvas.gameObject.SetActive(true);
			//zvezda.gameObject.SetActive(false);
			if( canvas != null ){
		
			canvas.gameObject.SetActive(true);
		}
		if( zvezda != null ){
		
			zvezda.gameObject.SetActive(false);
		}
			
			
	}
	} 
}
// if backpack.activeInHierarchy == false
