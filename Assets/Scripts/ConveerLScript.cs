using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Folder : MonoBehaviour
{
    public TextMeshProUGUI sizeText; // ������ �� TextMeshPro ��� Size
    public TextMeshProUGUI colorText; // ������ �� TextMeshPro ��� Color
    public TextMeshProUGUI transparencyText; // ������ �� TextMeshPro ��� Transparency
    public TextMeshProUGUI deskText; // ������ �� TextMeshPro ��� ����������� �������
    public TextMeshProUGUI resultText; // ������ �� TextMeshPro ��� ����������� ����������
    public Button trueButton; // ������ True
    public Button falseButton; // ������ False

    public AudioSource audioSource;

    private int count = 0; // �������
    private int currentLevel = 0; // ������� �������

    private string[] sizes = { "20x20x20", "30x30x30", "40x40x40", "10x10x10", "15x15x15", "25x25x25", "35x35x35" };
    private string[] colors = { "�������", "�����", "������", "�����" };
    private string[] transparencies = { "20%", "40%", "60%", "80%" };

    private string generatedSize;
    private string generatedColor;
    private string generatedTransparency;

    private int totalLevels = 5; // ����� ���������� �������
    private List<int> matchingLevels = new List<int>(); // ������ � ������������

    private void Start()
    {
        // ��������� ��������� ������� � ������������
        GenerateMatchingLevels();

        // ���������� ������������ ������� ��� ������
        trueButton.onClick.AddListener(OnTrueButtonClicked);
        falseButton.onClick.AddListener(OnFalseButtonClicked);

        // ������ ������ �������
        StartLevel();
    }

    private void GenerateMatchingLevels()
    {
        // ��������� ���������� ���������� ������� � ������������
        int countMatchingLevels = Random.Range(1, totalLevels + 1); // ��������� ���������� ���������� �� 1 �� totalLevels

        // ��������� ���������� �������� �������
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
        // ��������� ��������� ��������
        generatedSize = GeneratedSize();
        generatedColor = GeneratedColor();
        generatedTransparency = GeneratedTransparency();

        // ������������ �������
        string template = $"������:\n\n������: {generatedSize}\n����: {generatedColor}\n������������: {generatedTransparency}";
        deskText.text = template;

        // ��������� ������ ��� �����������
        if (matchingLevels.Contains(currentLevel)) // ��������, ��������� �� ������� � ��������
        {
            sizeText.text = generatedSize;
            colorText.text = generatedColor;
            transparencyText.text = generatedTransparency;
        }
        else
        {
            // ��������� ��������� ��������, ������� �� ��������� � ��������
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
            count++; // ����������� �������
            resultText.text = ("���������! �������: " + count);
        }
        else
        {
            resultText.text = ("�����������!");
        }
        NextLevel();
    }

    private void OnFalseButtonClicked()
    {
        audioSource.Play();
        if (!CheckTemplate())
        {
            count++; // ����������� �������
            resultText.text = ("���������!");
        }
        else
        {
            resultText.text = ("�����������!");
        }
        NextLevel();
    }

    private void NextLevel()
    {
        currentLevel++;

        if (currentLevel < totalLevels)
        {
            StartLevel(); // ������ ��������� �������
        }
        else
        {
            ShowResult();
            SceneManager.LoadScene(0); // �������� ��������� ����� ���� �������
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
        string resultMessage = $"���� �������: {count}/{totalLevels}\n";

        if (count >= 3)
        {
            resultMessage += "������� ����.";
        }
        else
        {
            resultMessage += "������� �� ����.";
        }

        resultText.text = resultMessage; // ����������� ���������� �� ������
        Debug.Log(resultMessage); // ����������� ����������
    }
}


