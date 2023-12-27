using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        isPaused = true;
        // ƒополнительные действи€ при паузе, например, остановка анимаций, звуков и т.д.
        Time.fixedDeltaTime = 0f; // ќстановка физики
    }

    void ResumeGame()
    {
        isPaused = false;
        // ƒополнительные действи€ при возобновлении игры
        Time.fixedDeltaTime = 0.00000002f; // ¬озобновление физики
    }
}