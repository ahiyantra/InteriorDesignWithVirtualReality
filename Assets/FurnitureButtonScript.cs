using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureButtonScript : GazeableButtonScript
{

    public Object prefab;

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

        // Set player mode to place furniture
        PlayerScript.instance.activeMode = InputMode.FURNITURE;


        // Set active furniture prefab to this prefab
        PlayerScript.instance.activeFurniturePrefab = prefab;

    }

}
