using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofScript : GazeableObjectScript
{
    public Renderer rend;

    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    //void Update()
    //{

    //}

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    public override void OnPress(RaycastHit hitInfo)
    {

        base.OnPress(hitInfo);

        //rend = GetComponent<Renderer>();
        //rend.enabled = true;

        if (PlayerScript.instance.activeMode == InputMode.ROOFSWITCH)
        {

            rend.enabled = !rend.enabled;
            
            /*
            if (rend.enabled == true)
            { 
                rend.enabled = false;
            }
            else
            {
                rend.enabled = true;
            }
            */
            /*
            Vector3 destLocation = hitInfo.point;

            destLocation.y = PlayerScript.instance.transform.position.y;

            PlayerScript.instance.transform.position = destLocation;
            */

        }

        /*
        else if (PlayerScript.instance.activeMode == InputMode.FURNITURE)
        {

            // Create the piece of furniture
            GameObject placedFurniture = GameObject.Instantiate(PlayerScript.instance.activeFurniturePrefab) as GameObject;


            // Set the position of the furniture
            placedFurniture.transform.position = hitInfo.point;


        }
        */

    }

}
