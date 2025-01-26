using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    [SerializeField] float money;


    public int trrry;
    public int total_money;
    public Text moneyText;
    public GameObject effect;
    public GameObject button;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;

    public AudioSource audioSource;

    public void Start()
    {
        audioSource.Play();
        money = PlayerPrefs.GetFloat("money");
        total_money = PlayerPrefs.GetInt("total_money");
    }

    public void ButtonClick()
    {
        audioSource.Play();
        money++;
        total_money++;
        PlayerPrefs.SetFloat("money", money);
        PlayerPrefs.SetInt("total_money", total_money);
        Instantiate(effect, button.GetComponent<RectTransform>().position.normalized, Quaternion.identity);
    }

    public void ButtonClick1Ach()
    {
        if (total_money >= 100)
        {
            money += 50;
            button1.SetActive(false);
        }
        PlayerPrefs.SetFloat("money", money);
    }

    public void ButtonClick2Ach()
    {
        audioSource.Play();
        if (total_money >= 1000)
        {
            money += 500;
            button2.SetActive(false);
        }
        PlayerPrefs.SetFloat("money", money);
    }

    public void ButtonClick3Ach()
    {
        audioSource.Play();
        if (trrry >=+ 10)
        {
            money += 500;
            button3.SetActive(false);
        }
        PlayerPrefs.SetFloat("money", money);
    }

    public void ButtonClick4Ach()
    {
        audioSource.Play();
        if (total_money >= 999999)
        {
            button4.SetActive(false);
            Application.Quit();
        }
    }

    public void ButtonClickIdle()
    {
        audioSource.Play();
        if (money >= 500)
        {
            money -= 500;
            trrry++;
            PlayerPrefs.SetInt("trrry", trrry);
            PlayerPrefs.SetFloat("money", money);
            StartCoroutine(IdleFarm());
        }
    }

    IEnumerator IdleFarm()
    {
        yield return new WaitForSeconds(1);
        money++; ;
        total_money++;
        PlayerPrefs.SetFloat("money", money);
        StartCoroutine(IdleFarm());
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = money.ToString();
    }
}
