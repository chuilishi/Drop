using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Serialization;

// [ExecuteInEditMode]
public class GridGenerator : MonoBehaviour
{
    public static int width = 36;
    public static int height = 16;

    public SpriteRenderer rock;

    public SpriteRenderer GetRock()
    {
        return rock;
    }

    public GameObject enemy;
    public GameObject character;
    public GameObject parent;
    public static List<List<int>> intGrid;
    public static List<List<GameObject>> objectsGrid;
    public static List<List<GameObject>> rockGrid;

    private void Start()
    {
        intGrid = new List<List<int>>();
        rockGrid = new List<List<GameObject>>();
        ReadGrid("level1");
        objectsGrid = new List<List<GameObject>>();
        //创建状态表格和物体表格
        for (int i = 0; i < width; i++)
        {
            rockGrid.Add(new List<GameObject>());
            objectsGrid.Add(new List<GameObject>());
            for (int j = 0; j < height; j++)
            {
                objectsGrid[i].Add(null);
                SpriteRenderer a = Instantiate(rock, new Vector2(-width / 2f + i - 0.5f, -height / 2f + j),
                    Quaternion.identity);
                a.transform.parent = parent.transform;
                GameObject o = a.gameObject;
                o.AddComponent<Rock>();
                Rock r = o.GetComponent<Rock>();
                r.index = new Vector2Int(i, j);
                r.enemy = enemy;
                r.character = character;
                o.AddComponent<PolygonCollider2D>();
                
                rockGrid[i].Add(a.gameObject);
                if (intGrid[i][j] != 1)
                {
                    a.enabled = false;
                    r.myType = GridType.Empty;
                }
                else r.myType = GridType.Rock;
                
            }
        }

        for (int i = 0; i <= width; i++)
        {
            for (int j = 0; j <= height; j++)
            {
                if (intGrid[i][j] == GridType.Enemy)
                {
                    GameObject e = Instantiate(enemy, new Vector2(-width / 2f + i - 0.5f, -height / 2f + j),
                        Quaternion.identity);
                    e.GetComponent<Enemy>().index = new Vector2Int(i, j);
                    e.GetComponent<Enemy>().myType = GridType.Enemy;
                    objectsGrid[i][j] = e.gameObject;
                }

                if (intGrid[i][j] == GridType.Character)
                {
                    GameObject c = Instantiate(character, new Vector2(-width / 2f + i - 0.5f, -height / 2f + j),
                        Quaternion.identity);
                    objectsGrid[i][j] = c.gameObject;
                    c.GetComponent<Character>().index = new Vector2Int(i, j);
                    c.GetComponent<Character>().myType = GridType.Character;
                }
            }
        }
    }

    private void OnApplicationQuit()
    {
        WriteGameSaveData("level1");
        Debug.Log("Quit!");
    }

    void WriteGameSaveData(string levelName)
    {
        string currentDirectory = Environment.CurrentDirectory;
        Debug.Log("FullName= " + currentDirectory);
        string filePath = Path.Combine(currentDirectory, "Assets", "levelInfo", levelName + ".txt");
        Debug.Log("filePath=  " + filePath);
        try
        {
            using FileStream fs = new(filePath, FileMode.Create);
            StreamWriter streamWriter = new(fs);
            for (int i = 0; i < intGrid.Count; i++)
            {
                for (int j = 0; j < intGrid[0].Count; j++)
                {
                    streamWriter.Write(intGrid[i][j].ToString());
                }

                streamWriter.Write("\n");
            }

            streamWriter.Flush();
        }
        catch (Exception ex)
        {
            Debug.Log("出现错误：" + ex.Message);
        }
    }

    void ReadGrid(string levelName)
    {
        string currentDirectory = Environment.CurrentDirectory;
        string filePath = Path.Combine(currentDirectory, "Assets", "levelInfo", levelName + ".txt");
        if (!File.Exists(filePath))
        {
            Debug.Log("没有此关卡");
        }

        using FileStream fs = new(filePath, FileMode.Open);
        StreamReader streamReader = new(fs);
        int num = 0;
        for (int i = 0; i < 100; i++)
        {
            intGrid.Add(new List<int>());
            for (int j = 0;; j++)
            {
                num = streamReader.Read();
                if (num == -1)
                {
                    intGrid.RemoveAt(intGrid.Count - 1);
                    return;
                }
                if (num == '\n') break;
                if (num - '0' == GridType.Empty) intGrid[i].Add(GridType.Empty);
                else if (num - '0' == GridType.Rock) intGrid[i].Add(GridType.Rock);
                else if (num - '0' == GridType.Enemy) intGrid[i].Add(GridType.Enemy);
                else if (num - '0' == GridType.Character) intGrid[i].Add(GridType.Character);
            }
        }
    }
}