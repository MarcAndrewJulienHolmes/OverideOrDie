using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinker_lorryA : MonoBehaviour
{


    Color lerpedColor = Color.black;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // Fetch the Renderer from the GameObject


        Renderer rend = GetComponent<Renderer>();

        lerpedColor = Color.Lerp(Color.black, Color.red, Mathf.PingPong(Time.time, 1));

        //Set the main Color of the Material to green
        rend.material.shader = Shader.Find("_Color");
        rend.material.SetColor("_Color", lerpedColor);

        //Find the Specular shader and change its Color to red
        rend.material.shader = Shader.Find("Specular");
        rend.material.SetColor("_SpecColor", lerpedColor);

    }
}
