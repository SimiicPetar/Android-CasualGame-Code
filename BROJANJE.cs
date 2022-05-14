using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BROJANJE : MonoBehaviour
{
	public Text txt;
	private int yourNumberVariable;
    // Start is called before the first frame update
    void Start()
    {
		 
        //txt.text = 'asd asd';
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = yourNumberVariable.ToString();
    }
	public void OnMouseDown(){
		yourNumberVariable = yourNumberVariable + 10;
	}

}
