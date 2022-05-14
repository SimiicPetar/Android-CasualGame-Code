using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript2 : MonoBehaviour
{
     public GameObject player;
      public GameObject player2;
    // Start is called before the first frame update
    void Start()
    {
        /*player = GameObject.FindWithTag("Respawn");
        player2 = GameObject.FindWithTag("Finish");*/
		Invoke("asd", 10f);
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    public void asd()
    {

        player.SetActive(false);
        player2.SetActive(true);
    }
}
