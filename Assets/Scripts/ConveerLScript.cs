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

    public int count = 0; // Счетчик

    private string[] sizes = { "20x20x20", "30x30x30", "40x40x40", "10x10x10", "15x15x15", "25x25x25", "35x35x35" };
    private string[] colors = { "Только красные", "Не красные", "Только желтые", "Не желтые", "Только зеленые", "Не зеленые", "Красные и зеленые", "Красные и желтые", "Желтые и зеленые" };
    private string[] transparencies = { "20%", "40%", "60%", "80%" };

    private string generatedSize;
    private string generatedColor;
    private string generatedTransparency;

    private void Start()
    {
        // Генерация случайных значений
        generatedSize = GeneratedSize();
        generatedColor = GeneratedColor();
        generatedTransparency = GeneratedTransparency();

        // Формирование шаблона
        string template = $"Шаблон:\nРазмер: {generatedSize}\nЦвет: {generatedColor}\nПрозрачность: {generatedTransparency}";
        deskText.text = template;

        // Установка текста для отображения
        sizeText.text = generatedSize;
        colorText.text = generatedColor;
        transparencyText.text = generatedTransparency;

        // Добавление обработчиков событий для кнопок
        trueButton.onClick.AddListener(OnTrueButtonClicked);
        falseButton.onClick.AddListener(OnFalseButtonClicked);
    }

    private string GeneratedSize()
    {
        // Генерация случайных значений
        return sizes[Random.Range(0, sizes.Length)];
    }

    private string GeneratedColor()
    {
        return colors[Random.Range(0, colors.Length)];
    }

    private string GeneratedTransparency()
    {
        return transparencies[Random.Range(0, transparencies.Length)];
    }

    private void OnTrueButtonClicked()
    {
        // Проверка на соответствие
        if (CheckTemplate())
        {
            count++; // Увеличиваем счетчик
            Debug.Log("Правильно! Вы нажали True. Счетчик: " + count);
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
        // Проверка соответствия сгенерированных значений
        return (sizeText.text.CompareTo(generatedSize) == 0) &&
               (colorText.text.CompareTo(generatedColor) == 0) &&
               (transparencyText.text.CompareTo(generatedTransparency) == 0);
    }
}
