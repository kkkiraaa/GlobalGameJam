using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public Vector2 pointA = new Vector2(9, 2); // Начальная точка
    public Vector2 pointB = new Vector2(0, 0); // Конечная точка
    public float duration = 2.0f; // Время перемещения

    private float elapsedTime = 0f;

    private void Update()
    {
        if (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration; // Нормализованное время
            transform.position = Vector2.Lerp(pointA, pointB, t);
        }
    }
}
