using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailTrigger : MonoBehaviour
{
    public GameObject FailEnabled;
    public GameObject CokkieSize1;
    public Rigidbody CookieRB1;
    public Animator playAnimation;
    public Animator playAnimationwalk;
    public AudioSource playSound;



    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fail")
        {
            FailEnabled.SetActive(true);
            CokkieSize1.transform.localScale = new Vector3(0.9f, 0.9f, -1f);
            CookieRB1.isKinematic = false;
            playAnimation.SetBool("isFail", true);
            playAnimationwalk.SetBool("isWalking", true);
            playSound.Play();

            Destroy(this);
        }
    }

}
