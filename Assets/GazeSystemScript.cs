﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeSystemScript : MonoBehaviour
{

    public GameObject reticle;

    public Color inactiveReticleColor = Color.gray;
    public Color activeReticleColor = Color.green;

    private GazeableObjectScript currentGazeObject;
    private GazeableObjectScript currentSelectedObject;

    private RaycastHit lastHit;

    // Start is called before the first frame update
    void Start()
    {

        SetReticleColor(inactiveReticleColor);

    }

    // Update is called once per frame
    void Update()
    {

        ProcessGaze();
        CheckForInput(lastHit);

    }

    public void ProcessGaze()
    {

        Ray raycastRay = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        Debug.DrawRay(raycastRay.origin, raycastRay.direction * 100);


        if (Physics.Raycast(raycastRay, out hitInfo))
        {
            // Do something to the object

            // Check if the object is interactable

            // Get the GameObject from the hitInfo
            GameObject hitObj = hitInfo.collider.gameObject;

            // Get the GazeableObject from the hit Object
            GazeableObjectScript gazeObj = hitObj.GetComponent<GazeableObjectScript>();

            // Object has a GazeableObject componenet
            if (gazeObj != null)
            {

                // Object we're looking at is different
                if (gazeObj != currentGazeObject)
                {
                    ClearCurrentObject();
                    currentGazeObject = gazeObj;
                    currentGazeObject.OnGazeEnter(hitInfo);
                    SetReticleColor(activeReticleColor);

                }
                else
                {
                    currentGazeObject.OnGaze(hitInfo);
                }

                lastHit = hitInfo;

            }
            else
            {
                ClearCurrentObject();
            }

        }

        // Check if the object is a new object (first time looking)

        // Set the reticle color
    }

    private void SetReticleColor(Color reticleColor)
    {
        // Set the color of the reticle
        reticle.GetComponent<Renderer>().material.SetColor("_Color", reticleColor);
    }

    private void CheckForInput(RaycastHit hitinfo)
    {

        // Check for down
        if (Input.GetMouseButtonDown(0) && currentGazeObject != null)
        {
            currentSelectedObject = currentGazeObject;
            currentSelectedObject.OnPress(hitinfo);
        }

        // Check for hold
        else if (Input.GetMouseButton(0) && currentSelectedObject != null)
        {
            currentSelectedObject.OnHold(hitinfo);
        }
        // Check for release
        else if (Input.GetMouseButtonUp(0) && currentSelectedObject != null)
        {
            currentSelectedObject.OnRelease(hitinfo);
            currentSelectedObject = null;
        }

    }

    private void ClearCurrentObject()
    {
        if (currentGazeObject != null)
        {
            currentGazeObject.OnGazeExit();
            SetReticleColor(inactiveReticleColor);
            currentGazeObject = null;
        }
    }

}
