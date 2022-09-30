using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO.Ports;
using System.IO;

public class Countdown : MonoBehaviour
{

    public float timeLeft = 20.0f;
    public Text startText; // used for showing countdown from 3, 2, 1 

    public SerialPort _port = new SerialPort("COM3", 115200);

    private void Start()
    {
        if (_port.IsOpen == false)
            _port.Open();

        _port.Write("00");
    }


    void Update()
    {
        timeLeft -= Time.deltaTime;
        startText.text = (timeLeft).ToString("0");
        if (timeLeft < 0)
        {
            //Do something useful or Load a new game scene depending on your use-case
            // Use this for initialization
          
                SceneManager.LoadScene("BIKE_MainScene2", LoadSceneMode.Single);
            }

           

        }

    }

