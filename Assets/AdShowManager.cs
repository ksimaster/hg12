using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
using UnityEngine.SceneManagement;
using Controllers;

public class AdShowManager : MonoBehaviour
{
    [SerializeField] [Min(60)] private int timerForAd; //>60
    [SerializeField] private GameObject timerObj; // Канвас на котором весит текст с таймером
    [SerializeField] private TMP_Text timerText; // TextMeshPro элемент на канвасе(текст о предупреждении)
    [SerializeField] private GameObject panel;
    private GameObject gameManager;
    
    

   

    private void Awake()
    {
        timerText.text = null;
    }

    void Start()
    {
        gameManager = GameObject.Find("[GameManager]");
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

        gameManager.GetComponent<GameManager>().ADPauseResumeGame(true);
        Camera.main.GetComponent<CameraController>().MouseSensitivityZero();
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
        yield return new WaitForSeconds(0.01f);
        /*float displayTimer = 0.1f;
        while (displayTimer > 0)
        {
            displayTimer -= Time.deltaTime;
            yield return null;
        } */
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
        yield return new WaitForSeconds(0.01f);
        /*displayTimer = 0.1f;
        while (displayTimer > 0)
        {
            displayTimer -= Time.deltaTime;
            yield return null;
        } */
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
        yield return new WaitForSeconds(0.01f);
        /*displayTimer = 0.1f;
        while (displayTimer > 0)
        {
            displayTimer -= Time.deltaTime;
            yield return null;
        }
        */
        StartCoroutine(AdShow());
        YandexGame.FullscreenShow();
        gameManager.GetComponent<GameManager>().ADPauseResumeGame(false);
        Camera.main.GetComponent<CameraController>().MouseSensitivityReturn();
        panel.SetActive(false);

        timerText.text = null;
    }


}