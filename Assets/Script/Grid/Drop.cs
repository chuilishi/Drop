using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Script;
public class Drop : GridBase
{
    public float MoveTime;
    protected virtual bool Move(Vector2Int destination) {
        Vector2 Destination = new Vector2(-GridGenerator.width/2f+destination.x-0.5f,-GridGenerator.height/2f+destination.y);
        if(GridGenerator.intGrid[destination.x][destination.y] == GridType.Rock)return false;
        if(GridGenerator.intGrid[destination.x][destination.y] == GridType.Enemy){
            if (myType == GridType.Enemy)
            {
                GridGenerator.intGrid[destination.x][destination.y] = GridType.Rock;
                Debug.Log("Enemy碰撞");
                Destroy(GridGenerator.objectsGrid[destination.x][destination.y]);
                GridGenerator.rockGrid[destination.x][destination.y].GetComponent<SpriteRenderer>().enabled = true;
                Destroy(gameObject);
                return true;
            }
            else if(myType == GridType.Character)
            {
                GridGenerator.objectsGrid[destination.x][destination.y].GetComponent<Drop>().Hitted(index);
            }
        }

        GridGenerator.intGrid[destination.x][destination.y] = myType;
        GridGenerator.intGrid[index.x][index.y] = 0;
        GridGenerator.objectsGrid[destination.x][destination.y] = gameObject;
        GridGenerator.objectsGrid[index.x][index.y] = null;
        
        index = destination;

        Animation anim = GetComponent<Animation>();
        AnimationCurve curve1;
        AnimationCurve curve2;
        AnimationClip clip = new(){
            legacy = true,
            name = "DropMovement"
        };
        Keyframe[] xKeys;
        Keyframe[] yKeys;

        xKeys = new Keyframe[]{
            new Keyframe(0f,transform.localPosition.x),
            new Keyframe(MoveTime,Destination.x),
        };
        yKeys = new Keyframe[]{
            new Keyframe(0f,transform.localPosition.y),
            new Keyframe(MoveTime,Destination.y),
        };

        curve1 = new AnimationCurve(xKeys);
        curve2 = new AnimationCurve(yKeys);
        clip.SetCurve("",typeof(Transform),"localPosition.x",curve1);
        clip.SetCurve("",typeof(Transform),"localPosition.y",curve2);
        anim.AddClip(clip,clip.name);
        anim.Play(clip.name);
        return true;
    }
    public virtual void Hitted(Vector2Int Comer)
    {
        Vector2Int vertical = index - Comer;
        if(Move(index+vertical)){
            return;
        }
        GameObject Clone = Instantiate(gameObject);
        Vector2Int horizental = new Vector2Int(vertical.y,vertical.x);
        if (!Clone.GetComponent<Drop>().Move(index + horizental)) Destroy(Clone);
        if(!Move(index-horizental))Destroy(gameObject);
    }
}