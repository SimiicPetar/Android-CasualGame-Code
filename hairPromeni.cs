using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hairPromeni : MonoBehaviour
{
     public GameObject background1;
	 public GameObject background2;
   

    void Start()
    {
        
    }
        

    void Update()
    {
       
        
    }

    public void Next()
     {
        
         
            background1.gameObject.SetActive(false);
            background2.gameObject.SetActive(true);
         
           
     }
    
     public void Previous()
     {
         
 background1.gameObject.SetActive(false);
            background2.gameObject.SetActive(true);
   
}
}
