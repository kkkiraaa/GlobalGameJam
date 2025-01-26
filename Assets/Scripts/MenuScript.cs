using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public Button firstButton;
    public Button secondButton;
    public Button thirdButton;
    public Button cancelButton;
    public Button exitButton; // Кнопка выхода

    public AudioSource audioSource;

    private void Start()
    {
        // Добавляем слушатели для кнопок
        firstButton.onClick.AddListener(() => OnButtonClick(1));
        secondButton.onClick.AddListener(() => OnButtonClick(2));
        thirdButton.onClick.AddListener(() => OnButtonClick(3));
        cancelButton.onClick.AddListener(OnCancelButtonClick);
    }

    private void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play(); 
        }
    }

    private void OnButtonClick(int sceneIndex)
    {
        PlaySound(); 
        SceneManager.LoadScene(sceneIndex); 
    }

    private void OnCancelButtonClick()
    {
        PlaySound(); 
        Application.Quit();
    }

    void Update()
    {
    }
}
