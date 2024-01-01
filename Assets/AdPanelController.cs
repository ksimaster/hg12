using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdPanelController : MonoBehaviour
{
    bool _isInGame;
    bool _isGamePaused;
    public int CompletedClownEvents;

    public event System.Action OnGameUnpaused;
    public event System.Action OnGamePaused;

    public GameObject panelAdShow;

    void Update()
    {
        /*
        if (panelAdShow.activeSelf)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0.1f;
            SoundManager.Instance.PauseAllSounds();
            OnGamePaused?.Invoke();
            _isGamePaused = true;
            _isInGame = false;

            // Отключить левую кнопку мыши
            DisableLeftMouseButton();
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
            SoundManager.Instance.UnpauseAllSounds();
            OnGameUnpaused?.Invoke();
            _isInGame = true;
            _isGamePaused = false;

            // Включить левую кнопку мыши
            EnableLeftMouseButton();
        }
        */
    }

    void DisableLeftMouseButton()
    {
        // Реализация отключения левой кнопки мыши
        Cursor.visible = true;
        if (Input.GetMouseButtonDown(0))
        {
            // Здесь можно добавить код, который предотвращает выполнение действий при нажатии на левую кнопку мыши
        }
    }

    void EnableLeftMouseButton()
    {
        // Реализация включения левой кнопки мыши
        Cursor.visible = false;
    }
}