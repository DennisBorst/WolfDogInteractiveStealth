using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractableObject
{
    Door,
    Camera
}

public class Interactable : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private Material highLightMat;
    [SerializeField] private InteractableObject typeOfInteractable;

    [Header("Doors")]
    [SerializeField] private Animator animDoor;

    [Header("Camera")]
    [SerializeField] private CameraEnemy cameraEnemyScript;

    private MeshRenderer meshRenderer;
    private Material startMat;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        startMat = meshRenderer.materials[0];
    }

    public void ChangeColor(bool _highLightMat)
    {
        if (_highLightMat)
        {
            meshRenderer.material = highLightMat;
        }
        else
        {
            meshRenderer.material = startMat;
        }
    }

    public void ActivateAction()
    {
        switch (typeOfInteractable)
        {
            case InteractableObject.Door:
                DoorAction();
                break;
            case InteractableObject.Camera:
                CameraAction();
                break;
            default:
                break;
        }
    }

    private void DoorAction()
    {
        animDoor.SetTrigger("OpenDoor");
    }

    private void CameraAction()
    {
        cameraEnemyScript.DisableCamera();
    }
}
