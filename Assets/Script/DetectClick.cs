using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class DetectClick : MonoBehaviour
{
    private void OnMouseDown() {
        Debug.Log("点到了!");
    }
}
