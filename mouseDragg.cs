using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseDragg : MonoBehaviour
{
     public ProgressBar Pb;
private float Valeur = 1;
 public float distance = 0.4f;
 public GameObject dugme;
 private float a;
 
void Update(){
	//Pb.BarValue = Valeur;
}
/*void OnMouseDown(){
	Pb.BarValue = Valeur;
	Valeur++;
	
	
}*/

     void OnMouseDrag()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
		
		

        transform.position = objectPos;
			Pb.BarValue = Valeur;
		a = Valeur;
	Valeur = Valeur + 1 * 0.5F ;
	if (a  >= 100){
		dugme.SetActive(true);
		Destroy(gameObject);
	}
    }
}
