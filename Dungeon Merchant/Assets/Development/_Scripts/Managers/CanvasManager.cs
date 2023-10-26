using DG.Tweening;
using TMPro;
using UnityEngine;

public class CanvasManager : Singleton<CanvasManager>
{
    [SerializeField] CanvasGroup shopGroup;
    [SerializeField] CanvasGroup bagGroup;
    [SerializeField] TextMeshProUGUI interactTMP;

    bool bagOpened;
    bool shopOpened;

    public void OpenShop()
    {
        if (shopOpened) return;
        OpenBag();
        shopOpened = true;
        shopGroup.DOFade(1, .25f);
    }

    public void CloseShop()
    {
        shopOpened = false;
        shopGroup.DOFade(0, .25f);
    }

    public void ToggleBag()
    {
        // Toggle
        bagOpened = !bagOpened;
        
        // Open bag
        if (bagOpened) bagGroup.DOFade(1, .25f);

        // Close bag
        else bagGroup.DOFade(0, .25f);
    }

    public void OpenBag()
    {
        bagOpened = true;
        bagGroup.DOFade(1, .25f);
    }

    public void CloseBag()
    {
        bagOpened = false;
        bagGroup.DOFade(0, .25f);
    }

    public void ToggleInteractText(bool value)
    {
        // Show if true
        if (value) interactTMP.DOFade(1, .25f);
        // Hide if false
        else interactTMP.DOFade(0, 1);
    }
}
