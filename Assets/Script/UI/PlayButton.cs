using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("aaaaaa");
        SceneManager.LoadScene("Testing");
    }
}
