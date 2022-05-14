using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragMouse : MonoBehaviour
{
   

 float distance = 10;
 
void Update(){
	//Pb.BarValue = Valeur;
}
/*void OnMouseDown(){
	Pb.BarValue = Valeur;
	Valeur++;
	
	
}*/

    public void OnMouseDrag()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
		
		

        transform.position = objectPos;
		
    }
}
