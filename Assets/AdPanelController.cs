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

            // ��������� ����� ������ ����
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

            // �������� ����� ������ ����
            EnableLeftMouseButton();
        }
        */
    }

    void DisableLeftMouseButton()
    {
        // ���������� ���������� ����� ������ ����
        Cursor.visible = true;
        if (Input.GetMouseButtonDown(0))
        {
            // ����� ����� �������� ���, ������� ������������� ���������� �������� ��� ������� �� ����� ������ ����
        }
    }

    void EnableLeftMouseButton()
    {
        // ���������� ��������� ����� ������ ����
        Cursor.visible = false;
    }
}