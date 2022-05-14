using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartLevel : MonoBehaviour
{

    public void RestartLevelButton()
    {
        Application.LoadLevel(Application.loadedLevel);

    }
}
