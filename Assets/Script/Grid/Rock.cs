using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
public class Rock : GridBase
{
    public GameObject enemy;
    public GameObject character;
    
    public void OnMouseDown()
    {
        if (KeyboardManager.state == GridType.Rock||KeyboardManager.state == GridType.BedRock)
        {
            if (gameObject.GetComponent<SpriteRenderer>().enabled)
            {
                GridGenerator.intGrid[index.x][index.y] = 0;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                GridGenerator.intGrid[index.x][index.y] = KeyboardManager.state;
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        if (KeyboardManager.state == GridType.Enemy||KeyboardManager.state == GridType.Character)
        {
            Debug.Log("2并且点到了");
            if (GridGenerator.intGrid[index.x][index.y] == KeyboardManager.state)
            {
                GridGenerator.intGrid[index.x][index.y] = 0;
                Destroy(GridGenerator.objectsGrid[index.x][index.y]);
            }
            else if (GridGenerator.intGrid[index.x][index.y] == GridType.Empty)
            {
                GridGenerator.intGrid[index.x][index.y] = KeyboardManager.state;
                GameObject d = null;
                d = Instantiate(KeyboardManager.state == GridType.Enemy ? enemy : character, transform.position, quaternion.identity);
                d.GetComponent<Drop>().index = index;
                GridGenerator.objectsGrid[index.x][index.y] = d.gameObject;
            }
        }
    }
}