using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class script1 : MonoBehaviour
{
    GameObject player;
    GameObject player2;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Respawn");
        player2 = GameObject.FindWithTag("Finish");
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene("Level2");
        }//file/buildsetings*/
    }
    public void OnMouseDown()
    {
        player.SetActive(false);
        player2.SetActive(true);
    }
}
/*
using UnityEngine;

//Attach this script to a GameObject to rotate around the target position.
public class Example : MonoBehaviour
{
    //Assign a GameObject in the Inspector to rotate around
    public GameObject target;

    void Update()
    {
        // Spin the object around the target at 20 degrees/second.
        transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);
    }
}
scene 1
public int a=0;

OnMouseDown(){
	a=1;
}
scene 2
if (a == 1){
	player.SetActive(true);
}
*/
