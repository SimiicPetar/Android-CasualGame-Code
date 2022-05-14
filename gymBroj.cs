using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gymBroj : MonoBehaviour
{
	public Text txt;
	public GameObject win;
	public GameObject lose;
	private int yourNumberVariable;
    // Start is called before the first frame update
    void Start()
    {
         StartCoroutine(StartCountdown());
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = yourNumberVariable.ToString();
	if(win != null){
		if(currCountdownValue == 20){
		if(yourNumberVariable >= 18){
			win.gameObject.SetActive(true);
			//lose.gameObject.SetActive(false);
			
		}
		}
		}
		if(lose != null){
		if(currCountdownValue == 21){
		if(yourNumberVariable < 18){
			//win.gameObject.SetActive(true);
			lose.gameObject.SetActive(true);
			
		}	
		}
		}
		}
    
	public void OnMouseDown(){
		yourNumberVariable = yourNumberVariable + 1;
	}
	float currCountdownValue;
 public IEnumerator StartCountdown(float countdownValue = 0)
 {
     currCountdownValue = countdownValue;
     while (currCountdownValue < 300)
     {
         //Debug.Log("Countdown: " + currCountdownValue);
		
         yield return new WaitForSeconds(1.5f);
         currCountdownValue++;
		 // txt.text = currCountdownValue.ToString();
     }
 }

}
