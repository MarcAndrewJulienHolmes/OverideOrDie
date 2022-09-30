using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Malctrain : MonoBehaviour
{

    public GameObject objMalc_sitting, objMalc_falling, objMalc_laying;
    public GameObject objMotorbike1, objMotorbike2, objMalc_objects;
    public bool crashed;
    //public GameObject Horn;

    // Use this for initialization
    void Start()
    {

        objMalc_sitting = (GameObject)GameObject.FindWithTag("Malc_sitting");
        objMalc_falling = (GameObject)GameObject.FindWithTag("Malc_falling");
        objMalc_laying = (GameObject)GameObject.FindWithTag("Malc_laying");
        objMotorbike1 = (GameObject)GameObject.FindWithTag("FirstBike");
        objMotorbike2 = (GameObject)GameObject.FindWithTag("SecondBike");
        objMalc_objects = (GameObject)GameObject.FindWithTag("Malc_objects");

        objMotorbike2.gameObject.SetActive(false);
        objMalc_falling.gameObject.SetActive(false);
        objMalc_laying.gameObject.SetActive(false);
        crashed = false;
        //Horn = (GameObject)GameObject.Find("HornSound");
        //Horn.gameObject.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {

        if (crashed == false & objMalc_objects.transform.position.x > -53.250F)
        {
            StartCoroutine(TrainCrash(this));
        }
    }

    public IEnumerator TrainCrash(Malctrain instance)
    {
        instance.crashed = true;

        Rigidbody gr = GameObject.FindWithTag("Malc_objects").GetComponent<Rigidbody>();
        gr.constraints = RigidbodyConstraints.FreezePosition;

        yield return new WaitForSeconds(0.0f);

        Destroy(objMotorbike1);
        Destroy(objMalc_sitting);
        //objMotorbike1.gameObject.SetActive(false);
        //objMalc_sitting.gameObject.SetActive(false);

        objMotorbike2.gameObject.SetActive(true);
        objMalc_falling.gameObject.SetActive(true);

        yield return new WaitForSeconds(1.0f);

        Destroy(objMalc_falling);

        objMalc_laying.gameObject.SetActive(true);

        yield return new WaitForSeconds(1.0f);

        //if (Horn.activeSelf == false)
        //{
        //    Horn.gameObject.SetActive(true);
        //    Debug.Log("here");

        //}
    }
}
