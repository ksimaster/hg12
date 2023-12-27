
using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using YG;


public class InfoTextUpdater : MonoBehaviour
{
    TextMeshProUGUI _text;
    private void Awake()
    {
        StopAllCoroutines();
        _text = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        PlayerInventoryManager.Instance.OnItemAcquired += HandleOnItemAcquired;
        PlayerInventoryManager.Instance.OnItemRemoved  += HandleOnItemRemoved;
        
    }
    private void OnDisable()
    {
        PlayerInventoryManager.Instance.OnItemAcquired -= HandleOnItemAcquired;
        PlayerInventoryManager.Instance.OnItemRemoved -= HandleOnItemRemoved;
    }
    void HandleOnItemRemoved()
    {
        CollectableID collectableID = PlayerInventoryManager.Instance.LastChangedItemID;
        switch (collectableID)
        {
            case CollectableID.Fuel:
                if (YandexGame.EnvironmentData.language == "ru")
                {
                    _text.SetText("Предмет 'Топливо' удален из инвентаря.");
                }
                if (YandexGame.EnvironmentData.language == "en")
                {
                    _text.SetText("Item 'Fuel' removed from your inventory.");
                }

                
                break;
        }
        StartCoroutine(TextFadeInAndOut());
    }
    void HandleOnItemAcquired()
    {
        CollectableID collectableID = PlayerInventoryManager.Instance.LastChangedItemID;
        switch (collectableID)
        {
            case CollectableID.KeyBlue:
                if (YandexGame.EnvironmentData.language == "ru")
                {
                    _text.SetText("Получен 'Синий ключ'");
                }
                if (YandexGame.EnvironmentData.language == "en")
                {
                    _text.SetText("Item 'Blue Key' acquired");
                }
                break;
            case CollectableID.KeyGreen:
                if (YandexGame.EnvironmentData.language == "ru")
                {
                    _text.SetText("Получен 'Зеленый ключ'");
                }
                if (YandexGame.EnvironmentData.language == "en")
                {
                    _text.SetText("Item 'Green Key' acquired");
                }
                
                break;
            case CollectableID.KeyRed:
                if (YandexGame.EnvironmentData.language == "ru")
                {
                    _text.SetText("Получен 'Красный ключ'");
                }
                if (YandexGame.EnvironmentData.language == "en")
                {
                    _text.SetText("Item 'Red Key' acquired");
                }

                
                break;
            case CollectableID.KeyBlack:
                if (YandexGame.EnvironmentData.language == "ru")
                {
                    _text.SetText("Получен 'Черный ключ'");
                }
                if (YandexGame.EnvironmentData.language == "en")
                {
                    _text.SetText("Item 'Black Key' acquired");
                }
                
                break;
            case CollectableID.Fuel:
                if (YandexGame.EnvironmentData.language == "ru")
                {
                    _text.SetText("Приобретен предмет 'Топливо'");
                }
                if (YandexGame.EnvironmentData.language == "en")
                {
                    _text.SetText("Item 'Fuel' acquired.");
                }
                
                break;
            case CollectableID.Firelighter:
                if (YandexGame.EnvironmentData.language == "ru")
                {
                    _text.SetText("Приобретен предмет 'Зажигалка'");
                }
                if (YandexGame.EnvironmentData.language == "en")
                {
                    _text.SetText("Item 'Firelighter' acquired");
                }

                
                break;
            default:
                break;
        }
        
       StartCoroutine(TextFadeInAndOut());
    }
    public void DoorLocked(CollectableID key)
    {
        if(key == CollectableID.KeyRed)
        {
            if (YandexGame.EnvironmentData.language == "ru")
            {
                _text.SetText("Дверь заперта. Вы должны найти 'Красный ключ'");
            }
            if (YandexGame.EnvironmentData.language == "en")
            {
                _text.SetText("Door is locked. You must find 'Red Key' ");
            }
            
        }
        else if(key == CollectableID.KeyBlack)
        {
            if (YandexGame.EnvironmentData.language == "ru")
            {
                _text.SetText("Дверь заперта. Вы должны найти 'Черный ключ'");
            }
            if (YandexGame.EnvironmentData.language == "en")
            {
                _text.SetText("Door is locked. You must find 'Black Key' ");
            }
            
        }
        else if(key == CollectableID.KeyGreen)
        {
            if (YandexGame.EnvironmentData.language == "ru")
            {
                _text.SetText("Дверь заперта. Вы должны найти 'Зеленый ключ'");
            }
            if (YandexGame.EnvironmentData.language == "en")
            {
                _text.SetText("Door is locked. You must find 'Green Key' ");
            }
            
        }
        else if(key == CollectableID.KeyBlue)
        {
            if (YandexGame.EnvironmentData.language == "ru")
            {
                _text.SetText("Дверь заперта. Вы должны найти 'Синий ключ'");
            }
            if (YandexGame.EnvironmentData.language == "en")
            {
                _text.SetText("Door is locked. You must find 'Blue Key' ");
            }
            
        }
        StopAllCoroutines();
        StartCoroutine(TextFadeInAndOut());
    }
    IEnumerator TextFadeInAndOut()
    {
        _text.DOFade(1, 2f);
        yield return new WaitForSeconds(3.2f);
        _text.DOFade(0, 0.5f);
        yield return null;
    }
}