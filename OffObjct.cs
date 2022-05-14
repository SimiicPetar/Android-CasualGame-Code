using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffObjct : MonoBehaviour
{
	public GameObject gameobjkt;
    // Start is called before the first frame update
    void Start()
    {
        if( gameobjkt != null){
				gameobjkt.gameObject.SetActive(false);
			}
    }

    // Update is called once per frame
    void Update()
    {
       if( gameobjkt != null){
				gameobjkt.gameObject.SetActive(false);
			}
    }
	
	
}
