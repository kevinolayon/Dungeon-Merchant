using UnityEngine;

public class Merchant : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        CanvasManager.Instance.OpenShop();
    }
}
