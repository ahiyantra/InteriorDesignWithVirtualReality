using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class GazeableButtonScript : GazeableObjectScript
{

    protected VirtualCanvasScript parentPanel;

    // Start is called before the first frame update
    void Start()
    {

        parentPanel = GetComponentInParent<VirtualCanvasScript>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetButtonColor(Color buttonColor)
    {
        GetComponent<Image>().color = buttonColor;
    }

    public override void OnPress(RaycastHit hitInfo)
    {
        base.OnPress(hitInfo);

        //SetActiveButton(Color.green);
        //SetButtonColor(Color.green);

        if (parentPanel != null)
        {
            parentPanel.SetActiveButton(this);
        }
        else
        {
            Debug.LogError("Button not a child of object with VRPanel component.", this);
        }

    }

}
