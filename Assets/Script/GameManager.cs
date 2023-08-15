using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject inGameMenu;
    [SerializeField]
    private GameObject congratulationUI;

    public static GameManager instance;
    public static int enemyNum = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleEscape();
    }

    public void enemyCounter(int addNum)
    {
        enemyNum += addNum;
        if (addNum == 0)
        {
            NextLevel(GridGenerator.instance.levelName);
            GridGenerator.instance.levelName += 1;
            enemyNum = 0;
        }
    }
    private void HandleEscape() //检测是否按下Esc键
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ShowIngameMenu();
        }
    }

    public void ShowIngameMenu() //显示暂停菜单
    {
        inGameMenu.SetActive(!inGameMenu.activeSelf);
        if(!inGameMenu.activeSelf) 
        {
            Time.timeScale = 1;
        }else //暂停游戏
        {
            Time.timeScale = 0;
        }
    }
    public void ShowCongratulationUI()
    {
        congratulationUI.SetActive(!congratulationUI.activeSelf);
        if (!congratulationUI.activeSelf)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    public void NextLevel(int levelName)
    {
        GridGenerator.instance.levelName = levelName;
    }
}
