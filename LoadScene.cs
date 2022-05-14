using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
	
	[SerializeField]
	private string aaa;
	
	public void Load()
	{
		
SceneManager.LoadScene(aaa);
	}
	
}
