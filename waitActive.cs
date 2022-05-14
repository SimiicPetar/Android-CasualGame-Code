using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waitActive : MonoBehaviour
{
    public GameObject asd1;
	public GameObject asd2;
	
	
	/*public GameObject text2;
	public Text txt2;*/
	//private int yourNumberVariable;
	//public Text txt;
    // Start is called before the first frame update
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
         //Debug.Log("Countdown: " + currCountdownValue);
		
         yield return new WaitForSeconds(1.5f);
         currCountdownValue++;
		  
     }
 }
 void Update()
    {
        
		
		if( currCountdownValue == 1 ){
			asd1.gameObject.SetActive(true);
			asd2.gameObject.SetActive(false);
			
		}
		
		
	}
	
	
}
