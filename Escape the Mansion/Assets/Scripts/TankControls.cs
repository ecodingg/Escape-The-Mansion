using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankControls : MonoBehaviour
{
    #region Variables
    
    //Variables
    private CharacterController controller;
    private float gravity = -9.81f;
    private float groundDistance = 0.4f;
    private Vector3 velocity;
    private bool isGrounded;
    
    //Input Action Variables
    private InputAction forwardAction, rightAction, sprintAction, interactAction;
    
    //Serialized Variables
    [SerializeField] private PlayerInput tankInput;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed = .5f;
    
    #endregion
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //If statement that creates strong gravity
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -0.25f;
        }
        
        //Get Actions from Input Actions
        forwardAction = tankInput.actions["Forward"];
        rightAction = tankInput.actions["Right"];
        sprintAction = tankInput.actions["Sprint"];
        interactAction = tankInput.actions["Interact"];
        
        //Floats for x and z axis movement
        float z = forwardAction.ReadValue<float>();
        float x = rightAction.ReadValue<float>();

        Vector3 move = transform.forward * z;
        transform.Rotate(0f, rotateSpeed * x, 0f);

        //Sprint change speed
        if (sprintAction.IsInProgress())
        {
            moveSpeed = 5f;
        }
        else
        {
            moveSpeed = 3f;
        }
        
        controller.Move(move * moveSpeed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
