using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public enum PlayerState
{
    Human,
    Ghost
}

public class SwitchState : MonoBehaviour
{
    [SerializeField] private LayerMask humanLayer;
    [SerializeField] private GameObject humanPrefab;
    [SerializeField] private GameObject humanObject;
    [SerializeField] private GameObject humanPanel;
    [SerializeField] private GameObject ghostPanel;

    //General
    private Camera cam;
    private PlayerState playerState;
    private PlayerController playerController;

    //Human
    private GameObject humanPrefabTemp;
    private Human humanScript;

    //Ghost
    private Ghost ghostScript;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        cam = Camera.main;
        humanScript = GetComponent<Human>();
        ghostScript = GetComponent<Ghost>();

        SwitchPlayerState(false);
    }

    private void Update()
    {
        switch (playerState)
        {
            case PlayerState.Human:
                Human();
                break;
            case PlayerState.Ghost:
                Ghost();
                break;
            default:
                break;
        }
    }

    private void Human()
    {
        //enter ghost mode
        if (Input.GetMouseButtonDown(1))
        {
            SwitchPlayerState(true);
        }

    }   

    private void Ghost()
    {
        //go back into human mode
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, ghostScript.minDisToHuman, humanLayer))
            {
                SwitchPlayerState(false);
            }
        }
    }

    private void SwitchPlayerState(bool _human)
    {
        //From human to ghost
        if (_human)
        {
            EnterGhost();
        }

        //From ghost to human
        if (!_human)
        {
            EnterHuman();
        }
    }

    private void EnterHuman()
    {
        playerState = PlayerState.Human;
        Destroy(humanPrefabTemp);
        humanObject.SetActive(true);

        humanScript.StartState();
        humanScript.enabled = true;
        humanPanel.SetActive(true);

        ghostScript.ExitState();
        ghostScript.enabled = false;
        ghostPanel.SetActive(false);

        cam.fieldOfView = humanScript.fieldOfView;
    }

    private void EnterGhost()
    {
        playerState = PlayerState.Ghost;
        humanPrefabTemp = Instantiate(humanPrefab, this.transform.position, this.transform.rotation);
        humanObject.SetActive(false);

        humanScript.ExitState();
        humanScript.enabled = false;
        humanPanel.SetActive(false);

        ghostScript.StartState();
        ghostScript.enabled = true;
        ghostPanel.SetActive(true);

        cam.fieldOfView = ghostScript.fieldOfView;
    }
}