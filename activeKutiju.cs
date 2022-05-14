using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class activeKutiju : MonoBehaviour
{
	public GameObject broj1;
	public GameObject broj2;
	public GameObject broj3;
	public GameObject broj4;
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
        
		if( currCountdownValue == 2 ){
			if( broj1 != null){
				broj1.gameObject.SetActive(true);
			}
			if( broj2 != null){
				broj2.gameObject.SetActive(true);
			}
			if( broj3 != null){
				broj3.gameObject.SetActive(true);
			}
			
			
		}
		if( currCountdownValue == 10 ){
			if( broj4 != null){
				broj4.gameObject.SetActive(true);
			}
			
			
		}
	}
	
	
    }
	/*public void OnMouseDown(){
		yourNumberVariable = yourNumberVariable + 1;
	}*/
	
	

//Debug.Log("Countdown: " + currCountdownValue);
//background[index].gameObject.SetActive(true);
