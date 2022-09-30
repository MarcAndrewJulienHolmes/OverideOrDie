using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CallMainScene2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Code());
	}

    // Update is called once per frame
    public IEnumerator Code(){

        yield return StartCoroutine(Waiting4 () );
        SceneManager.LoadScene("SKYBOX1", LoadSceneMode.Single);

    }

IEnumerator Waiting4()
{
    yield return new WaitForSeconds(8.0F);
}


}
