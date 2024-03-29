﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualCanvasScript : MonoBehaviour
{
    public GazeableButtonScript currentActiveButton; // private

    public Color unselectedColor = Color.white;
    public Color selectedColor = Color.green;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        LookAtPlayer();

    }

    public void SetActiveButton(GazeableButtonScript activeButton)
    {

        //If there was previously an active button, disable it.
        if (currentActiveButton != null)
        {
            currentActiveButton.SetButtonColor(unselectedColor);
        }

        if (activeButton != null && currentActiveButton != activeButton)
        {
            currentActiveButton = activeButton;
            currentActiveButton.SetButtonColor(selectedColor);
        }

        else
        {
            Debug.Log("Resetting");
            currentActiveButton = null;
            //Player.instance.activeMode = InputMode.NONE;
        }
    }

    public void LookAtPlayer()
    {
        Vector3 playerPos = PlayerScript.instance.transform.position;
        Vector3 vecToPlayer = playerPos - transform.position;

        Vector3 lookAtPos = transform.position - vecToPlayer;

        transform.LookAt(lookAtPos);
    }

}
