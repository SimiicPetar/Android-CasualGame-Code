using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAnim : MonoBehaviour
{
    
	
	private int yourNumberVariable;
	
    void Start()
    {
         StartCoroutine(StartCountdown());
    }

    
	 float currCountdownValue;
 public IEnumerator StartCountdown(float countdownValue = 0)
 {
     currCountdownValue = countdownValue;
     while (currCountdownValue < 17)
     {
        
         yield return new WaitForSeconds(1.0f);
         currCountdownValue++;
		 
     }
 }
 void Update()
    {
		
	if( currCountdownValue == 2 ){
			Destroy(gameObject);	
	}
	
    }
	
	
	
}
