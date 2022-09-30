using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;
using UnityEngine.SceneManagement;
using System.IO.Ports;
using System.IO;
using System.Threading;

public class CarScriptDilemma3b : MonoBehaviour
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
    public GameObject Tramhorn;
    public GameObject objTram;
    public GameObject objBarrierHolder;
    public GameObject objBarrierHolder2;
    public GameObject objlookright;
    public Rigidbody gr, lgr;

    //public GameObject WarningExclamation1;
    public AudioClip Welcome_voice_ignition;
    public AudioClip beep;

    public float decided, total;
    public bool PlayerCar;
    public static float ndecided;
    public static bool nPlayerCar;
    public float done; // done is just a 'flag' it's a real number with a decimal point
    public bool Welcomedone, stuck, freeze;


    public float trafficdone;
    public float falloverdone;
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
        stuck = false; freeze = false;


        Regina_Yelling = (GameObject)GameObject.Find("Yelling_anim1");
        TrafficAudioplaying = (GameObject)GameObject.Find("TrafficAudio");
        TrafficAudioplaying.gameObject.SetActive(true);

        GreenButton.gameObject.SetActive(false);
        trafficdone = 1.0F;
        //falloverdone = 1.0F;

        CollisionWarningSymbol1 = (GameObject)GameObject.Find("CollisionWarningFirst");
        CollisionWarningSymbol1.gameObject.SetActive(false);
        PedestrianWarningSymbol2 = (GameObject)GameObject.Find("PedestrianWarning_1");
        PedestrianWarningSymbol2.gameObject.SetActive(false);
        objlookright = (GameObject)GameObject.Find("Look_right");
        objlookright.gameObject.SetActive(false);
        //WarningExclamation1 = (GameObject)GameObject.Find("WarningExclam");
        //WarningExclamation1.gameObject.SetActive(false);
        objMalc_objects = (GameObject)GameObject.FindWithTag("Malc_objects");
        Redflashingmirror = (GameObject)GameObject.Find("Frame");
        Redflashingmirror.gameObject.SetActive(false);
        Blackframe = (GameObject)GameObject.Find("Blackframe");
        Blackframe.gameObject.SetActive(true);
        objTram = (GameObject)GameObject.FindWithTag("Tram");
        objBarrierHolder = (GameObject)GameObject.FindWithTag("BarrierHolder");
        objBarrierHolder2 = (GameObject)GameObject.FindWithTag("BarrierHolder2");

        Tramhorn = (GameObject)GameObject.Find("Tram_horn");
        Tramhorn.gameObject.SetActive(false);

        done = 0.0F; // set done = 0  i.e. haven't 'done' anything yet

        //Debug.Log("Start");
        total = 0.0f;
        wr = new StreamWriter("C:/Users/Biopac/Desktop/Helen.csv", true);  // maybe moves to update?
        wr.WriteLine("Dilemma 6," + System.DateTime.Now.ToString());
        wr.Flush();

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

        if (objMalc_objects.transform.position.x > -53.25F && trafficdone == 1.0F)
        {
            audio = GetComponent<AudioSource>();
            audio.PlayOneShot(Pedestrian_warning_dilemma1, 2.0F);
            //audio.PlayOneShot(Collision_warning_dilemma1, 2.0F);
            //WarningExclamation1.gameObject.SetActive(true);
            //PedestrianWarningSymbol2.gameObject.SetActive(true);
            PedestrianWarningSymbol2.gameObject.SetActive(true);
            wr.WriteLine("Collision warning," + System.DateTime.Now.ToString());
            wr.Flush();

            //Blackframe.gameObject.SetActive(false);
            //Redflashingmirror.gameObject.SetActive(true);
            trafficdone = 0.0F;

        }

        //if (objMalc_objects.transform.position.z < -27.0F && falloverdone == 1.0F)
        {


            //PedestrianWarningSymbol2.gameObject.SetActive(false);

            //audio = GetComponent<AudioSource>();

            //falloverdone = 0.0F;

            //Debug.Log("here2");




        }


        if (objCamera.transform.position.x > -53.75F && stuck == false)
        {
            objlookright.gameObject.SetActive(true);
            PedestrianWarningSymbol2.gameObject.SetActive(false);
            CollisionWarningSymbol1.gameObject.SetActive(true);
            Tramhorn.gameObject.SetActive(true);
            stuck = true;
            wr.WriteLine("Collision warning 2," + System.DateTime.Now.ToString());
            wr.Flush();
        }


        if (stuck==true && total <= 89.0f)
        {
            //drop barriers

            objBarrierHolder.transform.RotateAround(objBarrierHolder.transform.position, Vector3.left, 40 * Time.deltaTime);
            objBarrierHolder2.transform.RotateAround(objBarrierHolder2.transform.position, Vector3.right, 40 * Time.deltaTime);
            total = total + 40 * Time.deltaTime;

        }





        if (objMalc_objects.transform.position.x > -53.25F && done == 0.0F)
        {
            //only get here at the moment x>-39  AND done=0 i.e. hasn't been done yet




            done = 1.0F; // set done to be not equal to 0, i.e. won't ever get in here again, but integer of 1 means space has not been pressed
                         //WarningExclamation1.gameObject.SetActive(false);

            //Pedstrian HUD and audio

            //WarningExclamation1.gameObject.SetActive(true);



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

        //Debug.Log("freeze vehicles");


        if (stuck == true && freeze == false)
        { 
        gr = GameObject.Find("CarWaypointBased").GetComponent<Rigidbody>();
        gr.constraints = RigidbodyConstraints.FreezePosition;
        lgr = GameObject.Find("CarWaypointBased (2)").GetComponent<Rigidbody>();
        lgr.constraints = RigidbodyConstraints.FreezePosition;
        freeze = true; 
        }

        //this is the x position of the players head when driving- so will time things depending on where the head is down the road- moving in x position
        if (stuck==true && decided == 1.0F)
        {
            PlayerCar = false; // stop if no decision is made
            //decided = 0.0F;

            //Debug.Log("freeze vehicles");




            //if (Horn.activeSelf == false)
           // {
          //      Horn.gameObject.SetActive(true);
          


        //    }


            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log("here4" + decided);

                // decide to go forward
                audio = GetComponent<AudioSource>();
                audio.PlayOneShot(beep, 1.0F);
                Destroy(GameObject.Find("Override"));
                Destroy(GameObject.Find("Malc_objects"));

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

            if (objTram.transform.position.z > -9.0f)
            {
                wr.WriteLine("Stop," + System.DateTime.Now.ToString());
                wr.Flush(); 
                SceneManager.LoadScene("Train_Outcomestop2", LoadSceneMode.Single);
            }
        }



        {
            if (objCamera.transform.position.x > -53.5F && decided == 1.5F)

                SceneManager.LoadScene("Train_Outcomekill2", LoadSceneMode.Single);


        }

        // do the explosion thing

        // if at pedestrain do the running over thing
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
