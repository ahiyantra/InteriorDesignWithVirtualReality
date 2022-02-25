using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputMode
{

    NONE,
    TELEPORT,
    WALK,
    FURNITURE,
    TRANSLATE,
    ROTATE,
    SCALE,
    DRAG,
    ROOFSWITCH,
    SCREENSWITCH

}

public class PlayerScript : MonoBehaviour
{

    public static PlayerScript instance;
    public InputMode activeMode = InputMode.NONE;

    public Object activeFurniturePrefab;

    [SerializeField]
    private float playerSpeed = 3.0f;

    public GameObject LeftWall;
    public GameObject RightWall;

    public GameObject FrontWall;
    public GameObject BackWall;

    public GameObject Roof;
    public GameObject Floor;

    void Awake()
    {
        if (instance != null)
        {
            GameObject.Destroy(instance.gameObject);
        }

        instance = this;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        TryWalk();

    }

    public void TryWalk()
    {
        if (Input.GetMouseButton(0) && activeMode == InputMode.WALK)
        {
            Vector3 forward = Camera.main.transform.forward;

            Vector3 newPosition = transform.position + forward * Time.deltaTime * playerSpeed;

            if (newPosition.x < RightWall.transform.position.x-0.55 && newPosition.x > LeftWall.transform.position.x+0.55 &&
                newPosition.y < Roof.transform.position.y-0.45 && newPosition.y > Floor.transform.position.y+0.65 &&
                newPosition.z > BackWall.transform.position.z+0.55 && newPosition.z < FrontWall.transform.position.z-2.05)
            {
                transform.position = newPosition;
            }
        }
    }

}
