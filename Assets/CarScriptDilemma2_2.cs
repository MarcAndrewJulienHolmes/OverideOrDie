using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;
using UnityEngine.SceneManagement;
using System.IO.Ports;
using System.IO;
using System.Threading;

public class CarScriptDilemma2_2 : MonoBehaviour
{

    new AudioSource audio;
    public GameObject objCamera;


    public GameObject GreenButton;

    public GameObject Regina_Yelling;
    public GameObject TrafficAudioplaying;
    public AudioClip Collision_warning_dilemma1;
    public AudioClip Pedestrian_warning_dilemma1;
    public GameObject CollisionWarningSymbol1;
    public GameObject PedestrianWarningSymbol2;
    public GameObject Redflashingmirror;
    public GameObject Blackframe;
    public GameObject objMalc_objects;
    public GameObject Horn;
    public GameObject objSedan;
    public GameObject ObjLook_left;


    //public GameObject WarningExclamation1;
    public AudioClip Welcome_voice_ignition;
    public AudioClip beep;

    public float decided;
    public bool PlayerCar;
    public static float ndecided;
    public static bool nPlayerCar;
    public float done; // done is just a 'flag' it's a real number with a decimal point
    public bool Welcomedone;


    public float trafficdone;
    public float huh;
    public StreamWriter wr;



    // Use this for initialization- void Start- when code begins this is where from
    void Start()
    {
        decided = 1.0F; // i.e. you have decided not to stop
        Welcomedone = false;
        PlayerCar = true; // keep going


        //GameObject g = GameObject.Find("CarWaypointBased");
        //g.GetComponent<CarAIControl>().ndecided = decided;
        //g.GetComponent<CarAIControl>().nPlayerCar = PlayerCar;

        //ndecided = decided;
        //nPlayerCar = PlayerCar;

        //Finding the Green Button - but also setting them false

        GreenButton = (GameObject)GameObject.Find("Override");


        //Regina_Yelling = (GameObject)GameObject.Find("Yelling_anim1");
        TrafficAudioplaying = (GameObject)GameObject.Find("TrafficAudio");
        TrafficAudioplaying.gameObject.SetActive(true);

        GreenButton.gameObject.SetActive(false);
        trafficdone = 1.0F;

   
        PedestrianWarningSymbol2 = (GameObject)GameObject.Find("PedestrianWarning_1");
        PedestrianWarningSymbol2.gameObject.SetActive(false);
        ObjLook_left = (GameObject)GameObject.Find("Look_left");
        ObjLook_left.gameObject.SetActive(false);
        CollisionWarningSymbol1 = (GameObject)GameObject.Find("CollisionWarningFirst");
        CollisionWarningSymbol1.SetActive(false);
         //WarningExclamation1 = (GameObject)GameObject.Find("WarningExclam");
         //WarningExclamation1.gameObject.SetActive(false);
         objMalc_objects = (GameObject)GameObject.FindWithTag("Malc_objects");
        Redflashingmirror = (GameObject)GameObject.Find("Frame");
        Redflashingmirror.gameObject.SetActive(false);
        Blackframe = (GameObject)GameObject.Find("Blackframe");
        Blackframe.gameObject.SetActive(true);
        objSedan = (GameObject)GameObject.Find("Sedan_creased");

        Horn = (GameObject)GameObject.Find("HornSound");
        Horn.gameObject.SetActive(false);

        done = 0.0F; // set done = 0  i.e. haven't 'done' anything yet
        wr = new StreamWriter("C:/Users/Biopac/Desktop/Helen.csv", true);  // maybe moves to update?
        wr.WriteLine("Dilemma 4," + System.DateTime.Now.ToString());
        wr.Flush();

        //Debug.Log("Start");

    }

    // Update is called once per frame- void Update calls this every frame, the one that is running all the time. As soon as it starts the car is moving
    //so position is changing
    void Update()
    {
        //Debug.Log("Welcome here1");

        objCamera = (GameObject)GameObject.FindWithTag("SteeringWheel");

        if (!Welcomedone)
        {
            audio = GetComponent<AudioSource>();
            audio.PlayOneShot(Welcome_voice_ignition, 2.0F);
            Welcomedone = true;
            //Debug.Log("Welcome here2");
        }

        if (objMalc_objects.transform.position.z < -27.0F && trafficdone == 1.0F)
        { 

            audio = GetComponent<AudioSource>();
            audio.PlayOneShot(Pedestrian_warning_dilemma1, 2.0F);
            //audio.PlayOneShot(Collision_warning_dilemma1, 2.0F);
            //WarningExclamation1.gameObject.SetActive(true);
            //PedestrianWarningSymbol2.gameObject.SetActive(true);
            PedestrianWarningSymbol2.gameObject.SetActive(true);
            trafficdone = 0.0F;
            wr.WriteLine("Collision warning," + System.DateTime.Now.ToString());
            wr.Flush();

        }


        if (objMalc_objects.transform.position.z < -27.0F && done == 0.0F)
        {
            //only get here at the moment x>-39  AND done=0 i.e. hasn't been done yet


            done = 1.0F; // set done to be not equal to 0, i.e. won't ever get in here again, but integer of 1 means space has not been pressed
                        
       


            //Debug.Log("here3");
            GreenButton.gameObject.SetActive(true);

        }

      


        //if (objCamera.transform.position.z > -26.5F && objCamera.transform.position.z < -20.0F && done == 1.0F && decided != 1.5F)
        //{

        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        //Debug.Log("here4" + decided);

        //        // decide to go forward
        //        audio = GetComponent<AudioSource>();
        //        audio.PlayOneShot(beep, 1.0F);

        //        //keep the car going
        //        decided = 1.5F;
        //        PlayerCar = true; // keep going
        //    }
        //}



        //this is the x position of the players head when driving- so will time things depending on where the head is down the road- moving in x position
        if (objCamera.transform.position.z < -26.0F && decided == 1.0F)
        {
            PlayerCar = false; // stop if no decision is made
            //decided = 0.0F;

            //Debug.Log("freeze vehicles");


            Rigidbody gr = GameObject.Find("CarWaypointBased").GetComponent<Rigidbody>();
            gr.constraints = RigidbodyConstraints.FreezePosition;
            Rigidbody lgr = GameObject.Find("CarWaypointBased (2)").GetComponent<Rigidbody>();
            lgr.constraints = RigidbodyConstraints.FreezePosition;


            if (Horn.activeSelf == false)
            {
                Horn.gameObject.SetActive(true);
                PedestrianWarningSymbol2.gameObject.SetActive(false);
                CollisionWarningSymbol1.gameObject.SetActive(true);
                //WarningExclamation1.gameObject.SetActive(true);
                ObjLook_left.gameObject.SetActive(true);
                Blackframe.gameObject.SetActive(false);
                Redflashingmirror.gameObject.SetActive(true);
                audio = GetComponent<AudioSource>();
                audio.PlayOneShot(Collision_warning_dilemma1, 2.0F);
                //WarningExclamation1.gameObject.SetActive(true);
                wr.WriteLine("Collision warning 2," + System.DateTime.Now.ToString());
                wr.Flush();

            }


            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log("here4" + decided);

                // decide to go forward
                audio = GetComponent<AudioSource>();
                audio.PlayOneShot(beep, 1.0F);
                Destroy(GameObject.Find("Override"));
                //keep the car going
                decided = 1.5F;
                PlayerCar = true; // keep going
                wr.WriteLine("kill," + System.DateTime.Now.ToString());
                wr.Flush();

                //Rigidbody Bgr = GameObject.Find("CarWaypointBased (4)").GetComponent<Rigidbody>();
                //Destroy(Bgr);

                gr.constraints = RigidbodyConstraints.None;
                gr.AddForce(transform.forward * 500000.0F);

            }

            if (objSedan.transform.position.x < -62.0f)
            {
                wr.WriteLine("Stop," + System.DateTime.Now.ToString());
                wr.Flush();
                 SceneManager.LoadScene("BIKE_OutcomeStop_2", LoadSceneMode.Single);
            }


        }



        //if (decided == 1.0F)
        //{
        //    huh = objCamera.transform.position.z;
        //    //Debug.Log("huh is" + huh);

        //    if (huh < -26.0F)
        //    {


        //        //SceneManager.LoadScene("OutcomeStop", LoadSceneMode.Single);
        //    }

        //}





        {
            if (objCamera.transform.position.z < -26.5F && decided == 1.5F)

                SceneManager.LoadScene("BIKE_OutcomeKill_2", LoadSceneMode.Single);


        }

        // do the explosion thing

        // if at pedestrain do the running over thing
    }

    //public void ObjectTouched(object sender, InteractableObjectEventArgs e)
    //{
    //Debug.Log("here4" + decided);

    // decide to go forward
    // audio = GetComponent<AudioSource>();
    //audio.PlayOneShot(beep, 1.0F);

    //keep the car going
    //  decided = 1.5F;
    // PlayerCar = true; // keep going


    //}

}
