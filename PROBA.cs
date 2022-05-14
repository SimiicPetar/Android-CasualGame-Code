using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PROBA : MonoBehaviour
{
	
	public GameObject background;
	public GameObject background1;
	public GameObject background2;
	public GameObject background3;
    // Start is called before the first frame update
	public static int a;
    void Start()
    {
        if (a == 1){
			background.SetActive(true);
		}
		
    }

    // Update is called once per frame
    void Update()
    {
        if (a == 1){
			background.SetActive(true);
		}
		
    }
	public void player1biraj(){
		a=1;
	}
	public void player2biraj(){
		a=2;
	}
	
	/*public void player1()
    {
        background.SetActive(false);
        
    }*/
}
