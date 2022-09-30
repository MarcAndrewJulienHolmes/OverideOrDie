using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.IO;
using System.Threading;


public class PortCode : MonoBehaviour
{
    public static SerialPort _port = new SerialPort("COM3", 115200);

    //public var writer = new StreamWriter ("/Users/helenbrown/Desktop/Helen.txt", true);

    void Start()
    {
        //var writer = new StreamWriter("C:/Users/Biopac/Desktop/Helen.csv", true);  // maybe moves to update?

        //writer.WriteLine("PORT," + System.DateTime.Now.ToString() + ", OK");

        //Debug.Log("try opening");

        if (_port.IsOpen == false)
            _port.Open();

        //if (_port.IsOpen)
        //{
        //    Debug.Log("open"); writer.Write("open");
        //}
        //else
        //{
        //    Debug.Log("nope"); writer.Write("nope");
        //}


        _port.Write("00");

        //_port.Close();

        //writer.Flush();
        //writer.Close();
    }

    private void Update()
    {

    }

 
}
