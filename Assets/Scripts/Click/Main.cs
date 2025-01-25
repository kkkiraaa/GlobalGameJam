using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [SerializeField] int money;

    public Text moneyText;
    public void ButtonClick()
    {
        money++;
    }
    // Update is called once per frame
    void Update()
    {
        moneyText.text = money.ToString();
    }
}
