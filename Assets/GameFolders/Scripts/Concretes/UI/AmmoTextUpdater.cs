
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class AmmoTextUpdater : MonoBehaviour
{
    TextMeshProUGUI _text;
    private void Awake()
    {
        _text= GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        PlayerInventoryManager.Instance.OnAmmoChanged += HandleOnHealthChanged;
    }
    private void OnDisable()
    {
        PlayerInventoryManager.Instance.OnAmmoChanged -= HandleOnHealthChanged;
    }
    void HandleOnHealthChanged()
    {
        if (YandexGame.EnvironmentData.language == "ru")
        {
            _text.SetText("Патроны: " + PlayerInventoryManager.Instance.TotalAmmo);
        }
        if (YandexGame.EnvironmentData.language == "en")
        {
            _text.SetText("Ammo: " + PlayerInventoryManager.Instance.TotalAmmo);
        }

    }
    
     
}
