using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PlayerCon : MonoBehaviour
{
    Canvas canvas = null;
    public InvManager manager;
    public InvSystem inventory;
    public CharacterController controller;
    //public ItemObject item;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public TextMeshProUGUI itemsText;
    public int items;

    float moveX;
    float moveZ;

    bool isKeyboard;

    public bool useLookAt;
    void Start()
    {
        items = 0;
        SetItemText();
        isKeyboard = FindObjectOfType<InputControls>().keyboard;
    }

    void SetItemText()
    {
        itemsText.text = "Item: " + items.ToString();
    }

    void Update()
    {
        isKeyboard = FindObjectOfType<InputControls>().keyboard;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (isKeyboard)
        {
            moveX = Input.GetAxis("Horizontal");
            moveZ = Input.GetAxis("Vertical");
        }

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.transform.GetComponent<PointOfInterest>())
    //    {
    //        useLookAt = true;
    //    }
    //}
    //public void OnTriggerExit(Collider other)
    //{
    //    useLookAt = false;
    //}

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        ItemObject item = hit.collider.GetComponent<ItemObject>();
        if (item != null)
        {
            InvSystem.current.InventoryEvent();
            item.OnHandlePickupItem();
        }
    }
}
