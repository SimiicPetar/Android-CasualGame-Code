using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brojanje321 : MonoBehaviour
{
    private int yourNumberVariable;
	public GameObject stoj;
	public GameObject broj3;
	public GameObject broj2;
	public GameObject broj1;
	
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
		
	if( currCountdownValue == 6 ){
			stoj.gameObject.SetActive(false);	
	}
	if( currCountdownValue == 1 ){
			broj3.gameObject.SetActive(true);	
	}
	if( currCountdownValue == 3 ){
			broj3.gameObject.SetActive(false);	
			broj2.gameObject.SetActive(true);	
	}
	if( currCountdownValue == 5 ){
			broj1.gameObject.SetActive(true);
broj2.gameObject.SetActive(false);			
	}
	if( currCountdownValue == 7 ){	
broj1.gameObject.SetActive(false);			
	}
	
	
    }
	
	//canvas.gameObject.SetActive(true);
	//canvas.gameObject.SetActive(false);
}
