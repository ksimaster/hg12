﻿using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class AdShowManager : MonoBehaviour
{
    [SerializeField] [Min(60)] private int timerForAd; //>60
    [SerializeField] private GameObject timerObj; // Канвас на котором весит текст с таймером
    [SerializeField] private TMP_Text timerText; // TextMeshPro элемент на канвасе(текст о предупреждении)
    [SerializeField] private GameObject panel;

    private void Awake()
    {
        timerText.text = null;
    }

    void Start()
    {
        timerObj.SetActive(true);
        StartCoroutine(AdShow());
    }

    private IEnumerator AdShow()
    {
        float timer = 0f;
        while (timer < timerForAd)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        StartCoroutine(AdShowHelper());
    }

    IEnumerator AdShowHelper()
    {
        panel.SetActive(true);
        if (YandexGame.EnvironmentData.language == "ru")
        {
            timerText.text = "ДО ПОКАЗА РЕКЛАМЫ 3 СЕКУНДЫ";
        }
        if (YandexGame.EnvironmentData.language == "en")
        {
            timerText.text = "THE AD IS 3 SECONDS AWAY FROM BEING DISPLAYED";
        }
        if (YandexGame.EnvironmentData.language == "tr")
        {
            timerText.text = "REKLAM YAYINLANANA KADAR 3 SANİYE";
        }
        float displayTimer = 0.1f;
        while (displayTimer > 0)
        {
            displayTimer -= Time.deltaTime;
            yield return null;
        }
        if (YandexGame.EnvironmentData.language == "ru")
        {
            timerText.text = "ДО ПОКАЗА РЕКЛАМЫ 2 СЕКУНДЫ";
        }
        if (YandexGame.EnvironmentData.language == "en")
        {
            timerText.text = "THE AD IS 2 SECONDS AWAY FROM BEING DISPLAYED";
        }
        if (YandexGame.EnvironmentData.language == "tr")
        {
            timerText.text = "REKLAM YAYINLANANA KADAR 2 SANİYE";
        }
        displayTimer = 0.1f;
        while (displayTimer > 0)
        {
            displayTimer -= Time.deltaTime;
            yield return null;
        }
        if (YandexGame.EnvironmentData.language == "ru")
        {
            timerText.text = "ДО ПОКАЗА РЕКЛАМЫ 1 СЕКУНДЫ";
        }
        if (YandexGame.EnvironmentData.language == "en")
        {
            timerText.text = "THE AD IS 1 SECONDS AWAY FROM BEING DISPLAYED";
        }
        if (YandexGame.EnvironmentData.language == "tr")
        {
            timerText.text = "REKLAM YAYINLANANA KADAR 1 SANİYE";
        }
        displayTimer = 0.1f;
        while (displayTimer > 0)
        {
            displayTimer -= Time.deltaTime;
            yield return null;
        }

        StartCoroutine(AdShow());
        YandexGame.FullscreenShow();
        //panel.SetActive(false);
        timerText.text = null;
    }
}