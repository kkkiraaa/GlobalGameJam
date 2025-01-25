using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Folder : MonoBehaviour
{
    public TextMeshProUGUI sizeText; // ������ �� TextMeshPro ��� Size
    public TextMeshProUGUI colorText; // ������ �� TextMeshPro ��� Color
    public TextMeshProUGUI transparencyText; // ������ �� TextMeshPro ��� Transparency
    public TextMeshProUGUI deskText; // ������ �� TextMeshPro ��� ����������� �������
    public Button trueButton; // ������ True
    public Button falseButton; // ������ False

    public int count = 0; // �������

    private string[] sizes = { "20x20x20", "30x30x30", "40x40x40", "10x10x10", "15x15x15", "25x25x25", "35x35x35" };
    private string[] colors = { "������ �������", "�� �������", "������ ������", "�� ������", "������ �������", "�� �������", "������� � �������", "������� � ������", "������ � �������" };
    private string[] transparencies = { "20%", "40%", "60%", "80%" };

    private string generatedSize;
    private string generatedColor;
    private string generatedTransparency;

    private void Start()
    {
        // ��������� ��������� ��������
        generatedSize = GeneratedSize();
        generatedColor = GeneratedColor();
        generatedTransparency = GeneratedTransparency();

        // ������������ �������
        string template = $"������:\n������: {generatedSize}\n����: {generatedColor}\n������������: {generatedTransparency}";
        deskText.text = template;

        // ��������� ������ ��� �����������
        sizeText.text = generatedSize;
        colorText.text = generatedColor;
        transparencyText.text = generatedTransparency;

        // ���������� ������������ ������� ��� ������
        trueButton.onClick.AddListener(OnTrueButtonClicked);
        falseButton.onClick.AddListener(OnFalseButtonClicked);
    }

    private string GeneratedSize()
    {
        // ��������� ��������� ��������
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
        // �������� �� ������������
        if (CheckTemplate())
        {
            count++; // ����������� �������
            Debug.Log("���������! �� ������ True. �������: " + count);
        }
        else
        {
            Debug.Log("�����������! �� ������ True.");
        }
    }

    private void OnFalseButtonClicked()
    {
        // �������� �� ������������
        if (!CheckTemplate())
        {
            Debug.Log("���������! �� ������ False.");
        }
        else
        {
            Debug.Log("�����������! �� ������ False.");
        }
    }

    private bool CheckTemplate()
    {
        // �������� ������������ ��������������� ��������
        return (sizeText.text.CompareTo(generatedSize) == 0) &&
               (colorText.text.CompareTo(generatedColor) == 0) &&
               (transparencyText.text.CompareTo(generatedTransparency) == 0);
    }
}
