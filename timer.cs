using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
	public ProgressBar Pb;
	public Text txt;
    // Start is called before the first frame update
    void Start()
    {
         StartCoroutine(StartCountdown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	 float currCountdownValue;
 public IEnumerator StartCountdown(float countdownValue = 100)
 {
     currCountdownValue = countdownValue;
     while (currCountdownValue >= 0)
     {
         //Debug.Log("Countdown: " + currCountdownValue);
		Pb.BarValue = currCountdownValue;
         yield return new WaitForSeconds(1.0f);
         currCountdownValue=currCountdownValue - 4;
		  //txt.text = currCountdownValue.ToString();
     }
 }
}
