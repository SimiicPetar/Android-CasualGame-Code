using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeftRight : MonoBehaviour
{
    
	private int yourNumberVariable;
	public GameObject stop;
	public GameObject stop2;
    void Start()
    {
         StartCoroutine(StartCountdown());
    }

    
	 float currCountdownValue;
 public IEnumerator StartCountdown(float countdownValue = 0)
 {
     currCountdownValue = countdownValue;
     while (currCountdownValue < 300)
     {
         //Debug.Log("Countdown: " + currCountdownValue);
		
         yield return new WaitForSeconds(1.0f);
         currCountdownValue++;
		  
     }
 }
 void Update()
    {
        
		if( currCountdownValue == 8 ){
		transform.Translate(Vector3.right * 2 * Time.deltaTime);
		}
		if( currCountdownValue == 12 ){
		transform.Translate(Vector3.left * 2 * Time.deltaTime);
		}
		if( currCountdownValue == 15 ){
		transform.Translate(Vector3.right * 2 * Time.deltaTime);
		}
		if( currCountdownValue == 20 ){
		transform.Translate(Vector3.left * 2 * Time.deltaTime);
		}
		if( currCountdownValue == 25 ){
		transform.Translate(Vector3.right * 2 * Time.deltaTime);
		}
		if( currCountdownValue == 28 ){
		transform.Translate(Vector3.left * 2 * Time.deltaTime);
		}
		if( currCountdownValue == 30 ){
		transform.Translate(Vector3.right * 2 * Time.deltaTime);
		}
		if( currCountdownValue == 32 ){
		transform.Translate(Vector3.left * 2 * Time.deltaTime);
		}
		if( currCountdownValue == 34 ){
		transform.Translate(Vector3.right * 2 * Time.deltaTime);
		}
		if( currCountdownValue == 36 ){
		transform.Translate(Vector3.left * 2 * Time.deltaTime);
		}
		

		
		
		
		if( currCountdownValue == 46 ){
		stop.gameObject.SetActive(true);	
		}
		/*if( currCountdownValue == 41){
		stop2.gameObject.SetActive(false);	
		}*/
	}
	
	
    }
	




 // Moves the object forward at two units per second.
    //transform.position = new Vector3(0,0,2) * Time.deltaTime;

/*
Vector3.forward   // (0,  0,  1)
Vector3.back      // (0,  0,  -1)
Vector3.up        // (0,  1,  0)
Vector3.down      // (0,  -1, 0)
Vector3.right     // (1,  0,  0)
Vector3.left      // (-1, 0,  0)


transform.position += transform.forward * speed * Time.deltaTime;

colider iskljuci dodir
*/
