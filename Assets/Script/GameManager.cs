using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject inGameMenu;
    [SerializeField]
    private GameObject congratulationUI;

    public static GameManager instance;
    public static int enemyNum = 0;


    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        HandleEscape();
    }

    public void EnemyCounter(int addNum)
    {
        enemyNum += addNum;
        if (enemyNum == 0)
        {
            instance.ShowCongratulationUI();
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
    }
    
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
