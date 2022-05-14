using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject asd;
    public float sec;

    void Awake()
    {
		if( asd != null){
				 Destroy(asd, sec);
			}
        
    }
}
