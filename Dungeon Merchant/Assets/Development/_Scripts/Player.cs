using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed; // Control the movement speed
    [SerializeField] KeyCode interactKey;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;

    IInteractable currentInteractable;

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
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized * moveSpeed;

        // Apply the movement to the Rigidbody2D
        rb.velocity = movement;

        // Set animation parameters
        if (movement.sqrMagnitude > 0)
        {
            anim.SetFloat("horizontal", movement.x);
            anim.SetFloat("vertical", movement.y);
        }

        anim.SetFloat("speed", movement.sqrMagnitude);
    }

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
        if (currentInteractable != null) return;

        if (collision.TryGetComponent(out IInteractable interactable))
        {
            CanvasManager.Instance.ToggleInteractText(true);
            currentInteractable = interactable;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable))
        {
            CanvasManager.Instance.ToggleInteractText(false);
            currentInteractable = null;
        }
    }
}
