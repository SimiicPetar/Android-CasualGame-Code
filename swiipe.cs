using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Swipes { None, Up, Down, Left, TopLeft, BottomLeft, Right, TopRight,  BottomRight};

public class swiipe : MonoBehaviour
{
	public GameObject gameobjkt;
   public float minSwipeLength = 200f;
    Vector2 currentSwipe;

    private Vector2 fingerStart;
    private Vector2 fingerEnd;

    public static Swipes direction;

    void Update ()
    {
        SwipeDetection();
    }

    public void SwipeDetection ()
    {
        if (Input.GetMouseButtonDown(0)) {
            fingerStart = Input.mousePosition;
            fingerEnd  = Input.mousePosition;
        }

        if(Input.GetMouseButton(0)) {
            fingerEnd = Input.mousePosition;

            currentSwipe = new Vector2 (fingerEnd.x - fingerStart.x, fingerEnd.y - fingerStart.y);

            // Make sure it was a legit swipe, not a tap
            if (currentSwipe.magnitude < minSwipeLength) {
                direction = Swipes.None;
                return;
            }

            float angle = (Mathf.Atan2(currentSwipe.y, currentSwipe.x) / (Mathf.PI));
            Debug.Log(angle);
            // Swipe up
            if (angle>0.375f && angle<0.625f) {
                direction = Swipes.Up;
                gameobjkt.gameObject.SetActive(true);
                // Swipe down
            } else if (angle<-0.375f && angle>-0.625f) {
                direction = Swipes.Down;
               gameobjkt.gameObject.SetActive(true);
                // Swipe left
            } else if (angle<-0.875f || angle>0.875f) {
                direction = Swipes.Left;
                gameobjkt.gameObject.SetActive(true);
                // Swipe right
            } else if (angle>-0.125f && angle<0.125f) {
                direction = Swipes.Right;
                gameobjkt.gameObject.SetActive(true);
            }
            else if(angle>0.125f && angle<0.375f){
                direction = Swipes.TopRight;
                gameobjkt.gameObject.SetActive(true);
            }
            else if(angle>0.625f && angle<0.875f){
                direction = Swipes.TopLeft;
                gameobjkt.gameObject.SetActive(true);
            }
            else if(angle<-0.125f && angle>-0.375f){
                direction = Swipes.BottomRight;
                gameobjkt.gameObject.SetActive(true);
            }
            else if(angle<-0.625f && angle>-0.875f){
                direction = Swipes.BottomLeft;
                gameobjkt.gameObject.SetActive(true);
            }
        }

        if(Input.GetMouseButtonUp(0)) {
            direction = Swipes.None;  
        }
    }
}