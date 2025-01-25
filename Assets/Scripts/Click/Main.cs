using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    [SerializeField] int money;

    public int trrry;
    public int total_money;
    public Text moneyText;

    public void Start()
    {
        money = PlayerPrefs.GetInt("money");
        total_money = PlayerPrefs.GetInt("total_money");
    }

    public void ButtonClick()
    {
        money++;
        total_money++;
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt("total_money", total_money);
    }

    public void ButtonClick1()
    {
        if (total_money >= 100 && trrry < 1)
        {
            money += 50;
            trrry++;
        }
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt("trrry", trrry);
    } 

    // Update is called once per frame
    void Update()
    {
        moneyText.text = money.ToString();
    }
}
