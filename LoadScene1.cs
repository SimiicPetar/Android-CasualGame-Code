using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene1 : MonoBehaviour {
	
	[SerializeField]
	public string Prozor1;
	
	public void Load()
	{
		
SceneManager.LoadScene(Prozor1);
	}
	
}
