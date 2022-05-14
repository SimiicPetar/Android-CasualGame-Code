using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveKosa2 : MonoBehaviour
{
	static float broj = 0;
	public GameObject objekt;
    // Start is called before the first frame update
    void Start()
    {
        if( broj == 1){
			if(objekt != null){
				objekt.gameObject.SetActive(true);
			}
		}
    }

    // Update is called once per frame
    void Update()
    {
        if( broj == 1){
			if(objekt != null){
				objekt.gameObject.SetActive(true);
			}
		}
    }
	public void OnMouseDown(){
		broj = 1;
		Debug.Log("Countdown: " );
	}
	public void OffObjekt(){
		broj = 0;
		Debug.Log("Countdown: " );
	}
}
