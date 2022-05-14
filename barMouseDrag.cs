using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barMouseDrag : MonoBehaviour
{
   public ProgressBar Pb;
public float Valeur = 0.00001F;
 float distance = 0.9f;
 public GameObject dugme;
 private float a;
 public float brojDodaj = 0.00000001F;
 
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
	Valeur = Valeur + brojDodaj * 0.1F;
	if (a  >= 100){
		dugme.SetActive(true);
		Destroy(gameObject);
	}
    }
}
