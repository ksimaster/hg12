using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class ClownBoxTextUpdater : MonoBehaviour
{
    TextMeshProUGUI _text;
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        GameManager.Instance.OnCompletedClownIncreased += HandleOnClownBoxIncreased;
    }
    private void OnDisable()
    {
        GameManager.Instance.OnCompletedClownIncreased -= HandleOnClownBoxIncreased;
    }
    void HandleOnClownBoxIncreased()
    {
        if (YandexGame.EnvironmentData.language == "ru")
        {
            _text.SetText(GameManager.Instance.CompletedClownEvents + "/6 Коробок сожжено");
        }
        if (YandexGame.EnvironmentData.language == "en")
        {
            _text.SetText(GameManager.Instance.CompletedClownEvents + "/6 box burned");
        }
    }

}

