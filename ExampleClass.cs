

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
 
public class ExampleClass : MonoBehaviour
{
    void Start()
    {
        
        //Load a Texture (Assets/Resources/Textures/texture01.png)
        //var texture = Resources.Load<Texture2D>("Assets/theImage");

    }
	void Update(){
		
		var texture = Resources.Load<Texture2D>("Assets/theImage");
	}
	
}
 
 /*
 Things like this are better to connect in inspector. Add [SerializeField] tag before RawImage
 declaration and the slot will appear in the script inspector. Drag the image object into that 
 slot and it will always be there. Using things like Find and especially FindWithName hurts your 
 game performance.
*/