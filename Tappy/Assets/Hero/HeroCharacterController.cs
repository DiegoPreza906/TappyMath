using UnityEngine;

using System.Collections;
using System.Collections.Generic;


public class HeroCharacterController : MonoBehaviour
{

    //Animator
    private Animator animator;

    [SerializeField] LayerMask groundLayer;
    private float gravity = -50f;

    private CharacterController characterController;
    private Vector3 velocity;

    //Check Ground
    private bool isGrounded;

    //Horizontal Move
    private float horizontalInput;

    //Multiple Speed
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private float jumpHeigh = 2f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = 1;

        transform.forward = new Vector3(horizontalInput, 0, Mathf.Abs(horizontalInput) - 1);
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundLayer, QueryTriggerInteraction.Ignore);

        if (isGrounded && velocity.y < 0)
        {
            Debug.Log("Hay píso");
            velocity.y = 0;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }
        characterController.Move(new Vector3(horizontalInput * runSpeed, 0, 0) * Time.deltaTime);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y += Mathf.Sqrt(jumpHeigh * -2 * gravity);
        }
        /*
        if (isGrounded && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            velocity.y += Mathf.Sqrt(jumpHeigh * -2 * gravity);
        }
        */
        characterController.Move(velocity * Time.deltaTime);

        animator.SetFloat("Running",horizontalInput);

    }
}