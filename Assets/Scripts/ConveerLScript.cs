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

    private string[] sizes = { "20x20x20", "30x30x30", "40x40x40", "10x10x10", "15x15x15", "25x25x25", "35x35x35" };
    private string[] colors = { "������ �������", "�� �������", "������ ������", "�� ������", "������ �������", "�� �������", "������� � �������", "������� � ������", "������ � �������" };
    private string[] transparencies = { "20%", "40%", "60%", "80%" };

    private string generatedSize;
    private string generatedColor;
    private string generatedTransparency;

    private void Start()
    {
        GenerateTemplate();

        // ������������ �������
        string template = $"������:\n������: {generatedSize}\n����: {generatedColor}\n������������: {generatedTransparency}";
        deskText.text = template;

        //������ ��������
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
        // ��������� ��������� ��������
        generatedSize = sizes[Random.Range(0, sizes.Length)];
        generatedColor = colors[Random.Range(0, colors.Length)];
        generatedTransparency = transparencies[Random.Range(0, transparencies.Length)];


    }

    private void OnTrueButtonClicked()
    {
        // �������� �� ������������
        if (CheckTemplate())
        {
            Debug.Log("���������! �� ������ True.");
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
        // ����� �� ������ �������� ������ ��� �������� ������������
        // ��������, �� ������ �������� � ������� ��������� ����������
        // � ������ ������ ������ ���������� true ��� �������
        return true; // �������� �� ���� ������ ��������
    }
}
