using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class streliceSwitch : MonoBehaviour
{
   
    public GameObject[] background;
	public GameObject next;
	public GameObject previous; 
     int index;

    void Start()
    {
        index = 0;
    }
        

    void Update()
    {
        if(index >= 2)
           index = 2 ; 

        if(index < 0)
           index = 0 ;
	   
	   
	   
	  
        
    }

    public void Next()
     {
        index += 1;
    
		if(index == 2){
		   next.gameObject.SetActive(false);
		   previous.gameObject.SetActive(true);
	   }
	
         for(int i = 0 ; i < background.Length; i++)
         {
            background[i].gameObject.SetActive(false);
            background[index].gameObject.SetActive(true);
         }
            Debug.Log(index);
     }
    
     public void Previous()
     {
          index -= 1;
    
		if(index == 0){
		   next.gameObject.SetActive(true);
		   previous.gameObject.SetActive(false);
	   } 
	
        for(int i = 0 ; i < background.Length; i++)
         {
            background[i].gameObject.SetActive(false);
            background[index].gameObject.SetActive(true);
         }
            Debug.Log(index);
     }

   
}
   
