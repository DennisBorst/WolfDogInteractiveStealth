using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float fieldOfView;
    public float minDisToHuman;
    [SerializeField] private float minDisToInteractable;
    [SerializeField] private float ghostTime;
    [SerializeField] private LayerMask interactableLayer;

    private Camera cam;
    private float currentGhostTime;
    private Interactable lastSelectedInteractable;

    public void StartState()
    {
        currentGhostTime = ghostTime;
        cam = Camera.main;
    }

    private void Update()
    {
        currentGhostTime = Timer(currentGhostTime);
        if(currentGhostTime <= 0) { GameManager.Instance.GameOver(); }
        UIManager.Instance.GhostTime(currentGhostTime);

        CheckForInteractables();
    }

    private void CheckForInteractables()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, minDisToHuman, interactableLayer))
        {
            if(hit.collider.GetComponent<Interactable>() == null) { return; }
            lastSelectedInteractable = hit.collider.GetComponent<Interactable>();
            lastSelectedInteractable.ChangeColor(true);

            if (Input.GetMouseButtonDown(0))
            {
                lastSelectedInteractable.ActivateAction();
            }
        }
        else if(lastSelectedInteractable != null)
        {
            lastSelectedInteractable.ChangeColor(false);
            lastSelectedInteractable = null;
        }
    }

    public void ExitState()
    {
        if (lastSelectedInteractable != null)
        {
            lastSelectedInteractable.ChangeColor(false);
            lastSelectedInteractable = null;
        }
    }

    private float Timer(float timer)
    {
        timer -= Time.deltaTime;
        return timer;
    }
}
