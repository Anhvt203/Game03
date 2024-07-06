using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    [SerializeField] Button startGame;
    [SerializeField] Button changeWeapon;
    [SerializeField] Button openShop;
    // Start is called before the first frame update
    void Start()
    {
        startGame.onClick.AddListener(()=> StartGame());
        changeWeapon.onClick.AddListener(()=> ChangeWeapon());
    }
    private void StartGame()
    {
        GameManagers.Ins.PlayGame();
        LevelManager.Ins.OnInit();
	}
    private void ChangeWeapon()
    {
        GameManagers.Ins.ChangeWeapon();
    }

}