using UnityEngine;

public class Aminationn : MonoBehaviour
{
    public Animator animator;
    public float speed = 2f;
    public float rotationSpeed = 10f;
    public float mouseSensitivity = 200f; // sensibilidad del mouse

    private CharacterController controller;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //movimiento con el mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(0f, mouseX, 0f);

        float h = Input.GetAxisRaw("Horizontal"); 
        float v = Input.GetAxisRaw("Vertical");   

        // Dirección 
        Vector3 moveDir = (transform.right * h + transform.forward * v);

        ///camianndo
        bool isWalking = moveDir.sqrMagnitude > 0.01f;
        animator.SetBool("isWalking", isWalking);


        // --- ATAQUE: click izquierdo del mouse ---
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
        }
        
        if (isWalking)
        {
            moveDir = moveDir.normalized;

            // Mover usando CharacterController
            controller.SimpleMove(moveDir * speed);
        }
    }
}
