using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject inGameMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleEscape();
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
}
