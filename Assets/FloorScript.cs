using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : GazeableObjectScript
{
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    //void Update()
    //{

    //}

    public override void OnPress(RaycastHit hitInfo)
    {

        base.OnPress(hitInfo);

        if (PlayerScript.instance.activeMode == InputMode.TELEPORT)
        {

            Vector3 destLocation = hitInfo.point;

            destLocation.y = PlayerScript.instance.transform.position.y;

            PlayerScript.instance.transform.position = destLocation;

        }

        else if (PlayerScript.instance.activeMode == InputMode.FURNITURE)
        {

            // Create the piece of furniture
            GameObject placedFurniture = GameObject.Instantiate(PlayerScript.instance.activeFurniturePrefab) as GameObject;


            // Set the position of the furniture
            placedFurniture.transform.position = hitInfo.point;


        }
    }

}
