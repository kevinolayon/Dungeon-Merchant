using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed; // Control the movement speed
    [SerializeField] KeyCode interactKey;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;
    [SerializeField] List<Animator> equipmentAnimList;

    IInteractable currentInteractable;
    Vector2 movement;

    private void Update()
    {
        InteractInput();
    }

    void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        // Input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Movement vector calculation
        movement = new Vector2(horizontalInput, verticalInput).normalized * moveSpeed;

        // Apply the movement to the Rigidbody2D
        rb.velocity = movement;

        // Set animation parameters
        if (movement.sqrMagnitude > 0)
        {
            anim.SetFloat("horizontal", movement.x);
            anim.SetFloat("vertical", movement.y);
        }

        anim.SetFloat("speed", movement.sqrMagnitude);

        EquipmentAnim();
    }

    #region Equipment
    public void EquipmentAnim()
    {
        if (equipmentAnimList.Count <= 0) return;

        foreach (Animator anim in equipmentAnimList)
        {
            if (anim.gameObject.activeInHierarchy)
            {
                // Set animation parameters
                if (movement.sqrMagnitude > 0)
                {
                    anim.SetFloat("horizontal", movement.x);
                    anim.SetFloat("vertical", movement.y);
                }

                anim.SetFloat("speed", movement.sqrMagnitude);
            }
        }
    }
    
    // Sorry for bad implementation below, my bad because of short time
    public void ShowHelmet()
    {
        equipmentAnimList[0].gameObject.SetActive(true);
    }

    public void HideHelmet()
    {
        equipmentAnimList[0].gameObject.SetActive(false);
    }

    public void ShowArmor()
    {
        equipmentAnimList[1].gameObject.SetActive(true);
    }

    public void HideArmor()
    {
        equipmentAnimList[1].gameObject.SetActive(false);
    }
    #endregion

    public void InteractInput()
    {
        if (currentInteractable == null) return;

        if (Input.GetKeyDown(interactKey))
        {
            CanvasManager.Instance.ToggleInteractText(false);
            currentInteractable.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if already has a interface reference
        if (currentInteractable != null) return;

        // Try get interactable interface
        if (collision.TryGetComponent(out IInteractable interactable))
        {
            // Show interact text
            CanvasManager.Instance.ToggleInteractText(true);

            // Get interface reference
            currentInteractable = interactable;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable))
        {
            // Show interact text
            CanvasManager.Instance.ToggleInteractText(false);

            // Remove interface reference
            currentInteractable = null;
        }
    }
}
