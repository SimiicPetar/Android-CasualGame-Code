using System.Collections;
using System.Collections.Generic;
using UnityEngine;


	public class script : MonoBehaviour{
		public int superSize = 2;
		//private int _shotIndex = 0;
		
		private void Update(){
			/*ScreenCapture.CaptureScreenshot($"Assets/ScreenShot{_shotIndex}.png", superSize);
				_shotIndex++;*/
		}
		void OnMouseDown() {
			ScreenCapture.CaptureScreenshot($"Assets/ScreenShot.png", superSize);
			//ScreenCapture.CaptureScreenshot($"ScreenShot.png", superSize);
//ScreenCapture.CaptureScreenshot($"ScreenShot{_shotIndex}.png", superSize);
				//_shotIndex++;
			}
	}
	
	
	/* 
	string path = System.IO.Path.Combine(Application.dataPath, "File.xml");
UnityEditor.FileUtil.DeleteFileOrDirectory(path);
AssetDatabase.Refresh();

File.Delete (Application.persistentDataPath + "/save.ghoul");
	*/


	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	

	
