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

    /// <summary>
    /// Use this to fade CanvasGroup and toggle interactable and raycast.
    /// </summary>
    public static void ToggleGroup(CanvasGroup group, bool value)
    {
        if (value) group.DOFade(1, .25f);
        else group.DOFade(0, .25f);

        group.interactable = value;
        group.blocksRaycasts = value;
    }

    public void OpenShop()
    {
        if (shopOpened) return;
        OpenBag();
        shopOpened = true;
        ToggleGroup(shopGroup, true);
    }

    public void CloseShop()
    {
        shopOpened = false;
        ToggleGroup(shopGroup, false);
        CloseBag();
    }

    public void ToggleBag()
    {
        // Toggle
        bagOpened = !bagOpened;

        // Open bag
        if (bagOpened) ToggleGroup(bagGroup, true);

        // Close bag
        else
        {
            ToggleGroup(bagGroup, false);

            // Check if Shop is open and close it too
            if (shopOpened) CloseShop();
        }
    }

    public void OpenBag()
    {
        bagOpened = true;
        ToggleGroup(bagGroup, true);
    }

    public void CloseBag()
    {
        bagOpened = false;
        ToggleGroup(bagGroup, false);

        // Check if Shop is open and close it too
        if (shopOpened) CloseShop();
    }

    public void ToggleInteractText(bool value)
    {
        // Show if true
        if (value) interactTMP.DOFade(1, .25f);

        // Hide if false
        else interactTMP.DOFade(0, 1);
    }
}
