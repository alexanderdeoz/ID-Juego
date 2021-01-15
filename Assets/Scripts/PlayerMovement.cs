using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 12f;
    float x;
    float z;
    Vector3 move;

    // gravedad
    Vector3 velocity;
    public float gravity = -15f;

    // detectar si topamos el suelo
    public Transform groundCheck;
    float radius = 0.4f;
    public LayerMask mask;
    bool isGrounded = false;
    public float jumpForce = 1f;
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position,radius,mask);//devuelve si tocamos boo si tocamos el suelo
        if (isGrounded && velocity.y <0)
        {
            velocity.y = gravity; // resetea la elosidad
        }
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        move = transform.right * x + transform.forward * z; // desplazamiento
        controller.Move(move * speed * Time.deltaTime);

        //salto
        if (Input.GetButtonDown("Jump")&& isGrounded)
        {
            // formulamatematica para saltar
            velocity.y = Mathf.Sqrt(jumpForce*(-2)* gravity);
        }
        //salto

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime); // gravedad al movimiento 
    }
}
