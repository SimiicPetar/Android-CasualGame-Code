using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barDugme : MonoBehaviour
{
   public ProgressBar Pb;
   public GameObject dugme;
private int Valeur = 15;
 //float distance = 10;
 
void Update(){
	//Pb.BarValue = Valeur;
}
/*void OnMouseDown(){
	Pb.BarValue = Valeur;
	Valeur++;
	
	
}*/
	private int a;
    //public void OnMouseDrag
	public void asd()
    {
        /*Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
		
		

        transform.position = objectPos;*/
		Pb.BarValue = Valeur;
		a = Valeur;
	Valeur = Valeur + 15 ;
	if (a  >= 100){
		dugme.SetActive(true);
	}
    }
	
}
