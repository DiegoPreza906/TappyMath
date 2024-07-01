using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMats : MonoBehaviour
{
   public float speed = 6.0f;
    public float jumpForce = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            // Movimiento del personaje
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            moveDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            // Saltar
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }

        // Aplicar gravedad
        moveDirection.y -= gravity * Time.deltaTime;

        // Mover el controlador
        controller.Move(moveDirection * Time.deltaTime);
    }
}
