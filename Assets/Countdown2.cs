using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Countdown2 : MonoBehaviour
{

    public float timeLeft = 20.0f;
    public Text startText; // used for showing countdown from 3, 2, 1 


    void Update()
    {
        timeLeft -= Time.deltaTime;
        startText.text = (timeLeft).ToString("0");
        if (timeLeft < 0)
        {
            //Do something useful or Load a new game scene depending on your use-case
            // Use this for initialization

            SceneManager.LoadScene("Train1", LoadSceneMode.Single);
        }



    }

}