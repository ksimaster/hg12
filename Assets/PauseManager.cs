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
        // �������������� �������� ��� �����, ��������, ��������� ��������, ������ � �.�.
        Time.fixedDeltaTime = 0f; // ��������� ������
    }

    void ResumeGame()
    {
        isPaused = false;
        // �������������� �������� ��� ������������� ����
        Time.fixedDeltaTime = 0.00000002f; // ������������� ������
    }
}