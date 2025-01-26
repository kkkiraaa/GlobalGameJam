using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Folder : MonoBehaviour
{
    public TextMeshProUGUI sizeText; // Ссылка на TextMeshPro для Size
    public TextMeshProUGUI colorText; // Ссылка на TextMeshPro для Color
    public TextMeshProUGUI transparencyText; // Ссылка на TextMeshPro для Transparency
    public TextMeshProUGUI deskText; // Ссылка на TextMeshPro для отображения шаблона
    public TextMeshProUGUI resultText; // Ссылка на TextMeshPro для отображения результата
    public Button trueButton; // Кнопка True
    public Button falseButton; // Кнопка False

    public AudioSource audioSource;

    private int count = 0; // Счетчик
    private int currentLevel = 0; // Текущий уровень

    private string[] sizes = { "20x20x20", "30x30x30", "40x40x40", "10x10x10", "15x15x15", "25x25x25", "35x35x35" };
    private string[] colors = { "Красный", "Синий", "Зелёный", "Белый" };
    private string[] transparencies = { "20%", "40%", "60%", "80%" };

    private string generatedSize;
    private string generatedColor;
    private string generatedTransparency;

    private int totalLevels = 5; // Общее количество уровней
    private List<int> matchingLevels = new List<int>(); // Уровни с совпадениями

    private void Start()
    {
        // Генерация случайных уровней с совпадениями
        GenerateMatchingLevels();

        // Добавление обработчиков событий для кнопок
        trueButton.onClick.AddListener(OnTrueButtonClicked);
        falseButton.onClick.AddListener(OnFalseButtonClicked);

        // Начать первый уровень
        StartLevel();
    }

    private void GenerateMatchingLevels()
    {
        // Генерация случайного количества уровней с совпадениями
        int countMatchingLevels = Random.Range(1, totalLevels + 1); // Случайное количество совпадений от 1 до totalLevels

        // Генерация уникальных индексов уровней
        while (matchingLevels.Count < countMatchingLevels)
        {
            int randomLevel = Random.Range(0, totalLevels);
            if (!matchingLevels.Contains(randomLevel))
            {
                matchingLevels.Add(randomLevel);
            }
        }
    }

    private void StartLevel()
    {
        // Генерация случайных значений
        generatedSize = GeneratedSize();
        generatedColor = GeneratedColor();
        generatedTransparency = GeneratedTransparency();

        // Формирование шаблона
        string template = $"Шаблон:\n\nРазмер: {generatedSize}\nЦвет: {generatedColor}\nПрозрачность: {generatedTransparency}";
        deskText.text = template;

        // Установка текста для отображения
        if (matchingLevels.Contains(currentLevel)) // Проверка, совпадает ли уровень с шаблоном
        {
            sizeText.text = generatedSize;
            colorText.text = generatedColor;
            transparencyText.text = generatedTransparency;
        }
        else
        {
            // Генерация случайных значений, которые не совпадают с шаблоном
            sizeText.text = GeneratedSize();
            colorText.text = GeneratedColor();
            transparencyText.text = GeneratedTransparency();
        }
    }

    private string GeneratedSize()
    {
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
        audioSource.Play();
        if (CheckTemplate())
        {
            count++; // Увеличиваем счетчик
            resultText.text = ("Правильно! Счетчик: " + count);
        }
        else
        {
            resultText.text = ("Неправильно!");
        }
        NextLevel();
    }

    private void OnFalseButtonClicked()
    {
        audioSource.Play();
        if (!CheckTemplate())
        {
            count++; // Увеличиваем счетчик
            resultText.text = ("Правильно!");
        }
        else
        {
            resultText.text = ("Неправильно!");
        }
        NextLevel();
    }

    private void NextLevel()
    {
        currentLevel++;

        if (currentLevel < totalLevels)
        {
            StartLevel(); // Начать следующий уровень
        }
        else
        {
            ShowResult();
            SceneManager.LoadScene(0); // Показать результат после всех уровней
        }
    }

    private bool CheckTemplate()
    {
        return (sizeText.text.CompareTo(generatedSize) == 0) &&
               (colorText.text.CompareTo(generatedColor) == 0) &&
               (transparencyText.text.CompareTo(generatedTransparency) == 0);
    }

    private void ShowResult()
    {
        string resultMessage = $"Твой рейтинг: {count}/{totalLevels}\n";

        if (count >= 3)
        {
            resultMessage += "Экзамен сдан.";
        }
        else
        {
            resultMessage += "Экзамен не сдан.";
        }

        resultText.text = resultMessage; // Отображение результата на экране
        Debug.Log(resultMessage); // Логирование результата
    }
}


