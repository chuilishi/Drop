using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Drop
{
    private bool moveable = true;
    IEnumerator MoveController(){
        moveable = false;
        yield return new WaitForSeconds(MoveTime);
        moveable = true;
    }
    private void Update() {
        
        if(moveable&&Input.GetKey(KeyCode.UpArrow)){
            Move(new Vector2Int(index.x,index.y+1));
            StartCoroutine(MoveController());
        }
        else if(moveable&&Input.GetKey(KeyCode.DownArrow)){
            Move(new Vector2Int(index.x,index.y-1));
            StartCoroutine(MoveController());
        }
        else if(moveable&&Input.GetKey(KeyCode.RightArrow)){
            Move(new Vector2Int(index.x+1,index.y));
            StartCoroutine(MoveController());
        }
        else if(moveable&&Input.GetKey(KeyCode.LeftArrow)){
            Move(new Vector2Int(index.x-1,index.y));
            StartCoroutine(MoveController());
        }
    }
}
