using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCameraTextureScript : MonoBehaviour
{

    private WebCamTexture camTexture = null;

    public bool camPlay = false;

    public static Texture2D whiteTexture;

    // Start is called before the first frame update
    void Start()
    {

        camTexture = new WebCamTexture();

        //GetComponent<Renderer>().material.mainTexture = camTexture;

        GetComponent<Renderer>().material.mainTexture = whiteTexture;

        /*
        if (camPlay == true)
        {

            camTexture.Play();

        }
        else
        {

            camTexture.Stop();

        }
        */
    }

    // Update is called once per frame
    void Update()
    {

        if (camPlay == true)
        {

            //camTexture = new WebCamTexture();

            GetComponent<Renderer>().material.mainTexture = camTexture;

            camTexture.Play();

        }
        else
        {

            camTexture.Stop();

            GetComponent<Renderer>().material.mainTexture = whiteTexture;

        }

    }
}
