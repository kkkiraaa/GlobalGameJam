using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public int Column;
    public int Row;
    
    private UIManager uiManager;

    void Start() => uiManager = FindObjectOfType<UIManager>();
    void OnMouseDown() => uiManager.SelectButton(Column, Row);
}