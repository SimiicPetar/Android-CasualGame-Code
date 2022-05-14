using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ply2move : MonoBehaviour
{
    

    bool alive = true;
public float asd = 20;
    public float speed = 10;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;

    public float speedIncreasePerPoint = 2f;

    private void FixedUpdate ()
	
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * asd * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right  /*horizontalInput*/  * asd * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    private void Update () {
        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y < -5) {
            Die();
        }
	}

    public void Die ()
    {
        alive = false;
        // Restart the game
        Invoke("Restart", 2);
    }

    /*void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }*/
}
