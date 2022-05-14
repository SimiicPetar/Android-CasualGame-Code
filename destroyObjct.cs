using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyObjct : MonoBehaviour
{
	public GameObject gameobjkt;
	public float sec;
    // Start is called before the first frame update
    void Start()
    {
        if( gameobjkt != null){
				Destroy(gameobjkt, sec);
			}
    }

    // Update is called once per frame
    public void Update()
    {
       if( gameobjkt != null){
				Destroy(gameobjkt, sec);
			}
    }
	
	
}
