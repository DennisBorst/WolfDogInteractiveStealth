using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float moveSpeed;
    
    [Header("Camera Settings")]
    [SerializeField] private float cameraSensitivity;
    [SerializeField] private Transform camera;

    private float yCameraDirection;
    private CharacterController playerController;

    private void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        CameraRotation();
        PlayerMovement();
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;

        yCameraDirection -= mouseY;
        yCameraDirection = Mathf.Clamp(yCameraDirection, -70f, 70f);

        camera.transform.localRotation = Quaternion.Euler(yCameraDirection, 0f, 0f);
        this.transform.Rotate(Vector3.up * mouseX);
    }

    private void PlayerMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        playerController.Move(move * moveSpeed * Time.deltaTime);
    }
}
