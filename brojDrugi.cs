using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class brojDrugi : MonoBehaviour
{
	public GameObject text1;
	public GameObject text2;
	public Text txt2;
	private int yourNumberVariable;
	public Text txt;
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
		  txt.text = currCountdownValue.ToString();
     }
 }
 void Update()
    {
        txt2.text = yourNumberVariable.ToString();
		if( currCountdownValue == 17 ){
		if( yourNumberVariable <= 17 ){
			text1.gameObject.SetActive(true);
		}
	}
	if( currCountdownValue == 17 ){
		if( yourNumberVariable > 17 ){
			text2.gameObject.SetActive(true);
			
		}
	}
	
    }
	public void OnMouseDown(){
		yourNumberVariable = yourNumberVariable + 1;
	}
	
	
}
//Debug.Log("Countdown: " + currCountdownValue);
//background[index].gameObject.SetActive(true);
