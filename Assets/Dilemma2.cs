
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using VRTK;
    using UnityEngine.SceneManagement;
    using System.IO.Ports;
    using System.IO;
    using System.Threading;

public class Dilemma2 : MonoBehaviour
{
    new AudioSource audio;
    public GameObject objCamera;
    public GameObject Bang;
    public GameObject Stefaniscreaming;
    public GameObject GreenButton;
    public GameObject StefaniScared;
    public GameObject StefaniCrossing;
    public GameObject Regina_Yelling;
    public GameObject TrafficAudioplaying;
    public AudioClip Collision_warning_dilemma1;
    public AudioClip Pedestrian_warning_dilemma1;
    public GameObject CollisionWarningSymbol1;
    public GameObject PedestrianWarningSymbol2;
    public GameObject Redflashingmirror;
    public GameObject Blackframe;
    public GameObject FlamingLorry;
    public GameObject objrearcollisionyell;
    //public GameObject WarningExclamation1;
    public AudioClip Welcome_voice_ignition;
    public AudioClip beep;

    public float decided;
    public bool PlayerCar;
    public static float ndecided;
    public static bool nPlayerCar;
    public float done; // done is just a 'flag' it's a real number with a decimal point
    public bool Welcomedone;
    public float bangdone;
    public float screamingdone;
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

        //Finding the Green Button and Stefani- but also setting them false

        GreenButton = (GameObject)GameObject.Find("Override");
        FlamingLorry = (GameObject)GameObject.Find("CarFlamer");
        StefaniCrossing = (GameObject)GameObject.Find("stefanizebra");
        StefaniScared = (GameObject)GameObject.Find("Terrified");
        Regina_Yelling = (GameObject)GameObject.Find("Yelling_anim1");
        TrafficAudioplaying = (GameObject)GameObject.Find("TrafficAudio");
        objrearcollisionyell = (GameObject)GameObject.Find("Rearcollision_yellow");
        TrafficAudioplaying.gameObject.SetActive(true);
        StefaniScared.gameObject.SetActive(false);
        GreenButton.gameObject.SetActive(false);
        trafficdone = 1.0F;
        objrearcollisionyell.gameObject.SetActive(false);

        CollisionWarningSymbol1 = (GameObject)GameObject.Find("CollisionWarningFirst");
        CollisionWarningSymbol1.gameObject.SetActive(false);
        PedestrianWarningSymbol2 = (GameObject)GameObject.Find("PedestrianWarning_1");
        PedestrianWarningSymbol2.gameObject.SetActive(false);
        //WarningExclamation1 = (GameObject)GameObject.Find("WarningExclam");
        //WarningExclamation1.gameObject.SetActive(false);

        Redflashingmirror = (GameObject)GameObject.Find("Frame");
        Redflashingmirror.gameObject.SetActive(false);
        Blackframe = (GameObject)GameObject.Find("Blackframe");
        Blackframe.gameObject.SetActive(true);

        Bang = (GameObject)GameObject.Find("Explosions");
        Bang.gameObject.SetActive(false);
        done = 0.0F; // set done = 0  i.e. haven't 'done' anything yet
        bangdone = 0.0F;

        Stefaniscreaming = (GameObject)GameObject.Find("Screaming");
        Stefaniscreaming.gameObject.SetActive(false);
        done = 0.0F;
        screamingdone = 0.0F;

        wr = new StreamWriter("C:/Users/Biopac/Desktop/Helen.csv", true);  // maybe moves to update?
        wr.WriteLine("Dilemma 2," + System.DateTime.Now.ToString());
        wr.Flush();


    }

    // Update is called once per frame- void Update calls this every frame, the one that is running all the time. As soon as it starts the car is moving
    //so position is changing
    void Update()
    {

        objCamera = (GameObject)GameObject.FindWithTag("SteeringWheel");

        if (objCamera.transform.position.x > -62.0F && !Welcomedone)
        {
            audio = GetComponent<AudioSource>();
            audio.PlayOneShot(Welcome_voice_ignition, 2.0F);
            Welcomedone = true;
            //Debug.Log("here1");
        }

        if (objCamera.transform.position.x > -50.0F && bangdone == 0.0F && trafficdone == 1.0F)
        {
            bangdone = 1.0F;
            Bang.gameObject.SetActive(true);
            Blackframe.gameObject.SetActive(false);
            Redflashingmirror.gameObject.SetActive(true);

            //Debug.Log("here2");

            trafficdone = 0.0F;
            TrafficAudioplaying.gameObject.SetActive(false);
            audio = GetComponent<AudioSource>();
            audio.PlayOneShot(Collision_warning_dilemma1, 2.0F);
            //WarningExclamation1.gameObject.SetActive(true);
            CollisionWarningSymbol1.gameObject.SetActive(true);
            objrearcollisionyell.gameObject.SetActive(true);
            wr.WriteLine("Collision warning," + System.DateTime.Now.ToString());
            wr.Flush();


        }


        if (objCamera.transform.position.x > -41.0F && done == 0.0F)
        {
            //only get here at the moment x>-39  AND done=0 i.e. hasn't been done yet

            StefaniCrossing.gameObject.SetActive(true);
            done = 1.0F; // set done to be not equal to 0, i.e. won't ever get in here again
            //WarningExclamation1.gameObject.SetActive(false);
           
            //Pedstrian HUD and audio
            PedestrianWarningSymbol2.gameObject.SetActive(true);
            audio = GetComponent<AudioSource>();
            audio.PlayOneShot(Pedestrian_warning_dilemma1, 2.0F);
            //WarningExclamation1.gameObject.SetActive(true);
            CollisionWarningSymbol1.gameObject.SetActive(false);
            objrearcollisionyell.gameObject.SetActive(false);
            wr.WriteLine("Collision warning 2," + System.DateTime.Now.ToString());
            wr.Flush();

            //Debug.Log("here3");
            GreenButton.gameObject.SetActive(true);

        }


        if (objCamera.transform.position.x > -35.0F && screamingdone == 0.0F)
        {
            StefaniCrossing.gameObject.SetActive(false);
            StefaniScared.gameObject.SetActive(true);
            screamingdone = 1.0F;
            Stefaniscreaming.gameObject.SetActive(true);

            }

        if (done == 1.0F && decided != 1.5F)
        {
            Debug.Log("==" + decided);
            //if (GameObject.Find("Override").GetComponent<VRTK_InteractableObject>() != null)
            //{
            //    GameObject.Find("Override").GetComponent<VRTK_InteractableObject>().InteractableObjectTouched += new InteractableObjectEventHandler(ObjectTouched);
            //}

            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log("here4" + decided);

                // decide to go forward
                audio = GetComponent<AudioSource>();
                audio.PlayOneShot(beep, 1.0F);
                wr.WriteLine("kill," + System.DateTime.Now.ToString());
                wr.Flush();

                //keep the car going
                decided = 1.5F;
                PlayerCar = true; // keep going
            }

        }
        //this is the x position of the players head when driving- so will time things depending on where the head is down the road- moving in x position
        if (objCamera.transform.position.x > -30.5F && decided == 1.0F)
        {
            PlayerCar = false; // stop if no decision is made
            //decided = 0.0F;

            Destroy(GameObject.Find("Override"));

            Rigidbody gr = GameObject.Find("CarWaypointBased").GetComponent<Rigidbody>();
            gr.constraints = RigidbodyConstraints.FreezePosition;

            // do the explosion thing

        }

        if (decided == 1.0F)
        {
            huh = FlamingLorry.transform.position.x;
            Debug.Log("huh is" + huh);

            if (huh > -33F)
            {
                wr.WriteLine("Stop," + System.DateTime.Now.ToString());
                wr.Flush(); 
                huh = FlamingLorry.transform.position.x;
                Debug.Log("huh final is" + huh);
                SceneManager.LoadScene("Lorry_OutcomeStop_2", LoadSceneMode.Single);
            }

        }




        {
            if (objCamera.transform.position.x > -30F && decided == 1.5F)

                SceneManager.LoadScene("Lorry_OutcomeKill_2", LoadSceneMode.Single);


        }

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

