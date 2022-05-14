using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nestajeKutijaRuka : MonoBehaviour
{
	public GameObject broj1;
	public GameObject broj2;
	public GameObject broj3;
	public GameObject broj4;
	public GameObject broj5;
	
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
			broj1.gameObject.SetActive(true);
			broj2.gameObject.SetActive(true);
			
		}
		if( currCountdownValue == 2 ){
			broj1.gameObject.SetActive(false);
			broj2.gameObject.SetActive(false);
			
		}
		
	}
	
	
    }
	/*public void OnMouseDown(){
		yourNumberVariable = yourNumberVariable + 1;
	}*/
	
	

//Debug.Log("Countdown: " + currCountdownValue);
//background[index].gameObject.SetActive(true);
