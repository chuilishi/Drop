using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardManager : MonoBehaviour
{
    public static int state = 0;
    private void Update(){
        if(Input.GetKeyDown(KeyCode.Alpha0)){
            state = 0;
            Debug.Log("state = 1");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha1)){
            state = 1;
            Debug.Log("state = 1");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2)){
            state = 2;
            Debug.Log("state = 2");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3)){
            state = 3;
            Debug.Log("state = 3");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha4)){
            state = 4;
            Debug.Log("state = 4");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha5)){
            state = 5;//移动模式
            Debug.Log("state = 5");
        }
    }
}