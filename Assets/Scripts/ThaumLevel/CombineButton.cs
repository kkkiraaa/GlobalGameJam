using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineButton : MonoBehaviour
{
    public UIManager uiManager;

    void OnMouseDown() => uiManager.OnCombinePressed();
}
