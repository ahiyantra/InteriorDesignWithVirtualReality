using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeButtonScript : GazeableButtonScript
{
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    //void Update()
    //{

    //}

    [SerializeField]
    private InputMode mode;

    public override void OnPress(RaycastHit hitInfo)
    {
        base.OnPress(hitInfo);

        if (parentPanel.currentActiveButton != null)
        {
            PlayerScript.instance.activeMode = mode;
        }
    }

}
