using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Folder : MonoBehaviour
{
    public TextMeshProUGUI sizeText; // Ссылка на TextMeshPro для Size
    public TextMeshProUGUI colorText; // Ссылка на TextMeshPro для Color
    public TextMeshProUGUI transparencyText; // Ссылка на TextMeshPro для Transparency
    public TextMeshProUGUI deskText; // Ссылка на TextMeshPro для отображения шаблона
    public Button trueButton; // Кнопка True
    public Button falseButton; // Кнопка False

    private string[] sizes = { "20x20x20", "30x30x30", "40x40x40", "10x10x10", "15x15x15", "25x25x25", "35x35x35" };
    private string[] colors = { "Только красные", "Не красные", "Только желтые", "Не желтые", "Только зеленые", "Не зеленые", "Красные и зеленые", "Красные и желтые", "Желтые и зеленые" };
    private string[] transparencies = { "20%", "40%", "60%", "80%" };

    private string generatedSize;
    private string generatedColor;
    private string generatedTransparency;

    private void Start()
    {
        GenerateTemplate();

        // Формирование шаблона
        string template = $"Шаблон:\nРазмер: {generatedSize}\nЦвет: {generatedColor}\nПрозрачность: {generatedTransparency}";
        deskText.text = template;

        //Запуск подходов
        for (int i = 0; i < 5; i++)
        {
            GenerateTemplate();
        }
        GenerateTemplate();
        trueButton.onClick.AddListener(OnTrueButtonClicked);
        falseButton.onClick.AddListener(OnFalseButtonClicked);
    }

    private void GenerateTemplate()
    {
        // Генерация случайных значений
        generatedSize = sizes[Random.Range(0, sizes.Length)];
        generatedColor = colors[Random.Range(0, colors.Length)];
        generatedTransparency = transparencies[Random.Range(0, transparencies.Length)];


    }

    private void OnTrueButtonClicked()
    {
        // Проверка на соответствие
        if (CheckTemplate())
        {
            Debug.Log("Правильно! Вы нажали True.");
        }
        else
        {
            Debug.Log("Неправильно! Вы нажали True.");
        }
    }

    private void OnFalseButtonClicked()
    {
        // Проверка на соответствие
        if (!CheckTemplate())
        {
            Debug.Log("Правильно! Вы нажали False.");
        }
        else
        {
            Debug.Log("Неправильно! Вы нажали False.");
        }
    }

    private bool CheckTemplate()
    {
        // Здесь вы можете добавить логику для проверки соответствия
        // Например, вы можете сравнить с заранее заданными значениями
        // В данном случае просто возвращаем true для примера
        return true; // Замените на вашу логику проверки
    }
}
