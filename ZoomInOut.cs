using UnityEngine;
using UnityEngine.UI; //important, to activate communication with UI objects //penting, untuk mengaktifkan komunikasi dengan objek UI

public class ZoomInOut : MonoBehaviour {
public Slider slider;
public Camera cam;

void Start()
{
//start value of the slider from the smallest zoom point
//mulai nilai slider dari zoom paling kecil
slider.value = slider.maxValue;
}

void Update () {
cam.fieldOfView = slider.value;
}
}