using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioCollision : MonoBehaviour
{
	public AudioSource audioData;
	
    void OnCollisionEnter(){
		
		
		if( audioData != null){
				audioData.Play(0);
			}
	}
	
}
