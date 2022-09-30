using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTram : MonoBehaviour {

    public GameObject objCamera;
    //public GameObject Horn;
    private float speed;

    void Start()
    {
        //   Horn = (GameObject)GameObject.Find("HornSound");
        // Horn.gameObject.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {

        speed = 0.35F;
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        //if (objCamera.transform.position.z < -23.0F && Horn.activeSelf == false)
        //{
        //    Horn.gameObject.SetActive(true);
        //    Debug.Log("here");

        //}
    }

}