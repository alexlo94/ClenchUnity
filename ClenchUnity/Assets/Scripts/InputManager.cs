using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour {	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            StartCoroutine(StartGame());
        }
	}

    IEnumerator StartGame()
    {
        this.gameObject.GetComponent<AudioSource>().Play();
        while (this.gameObject.GetComponent<AudioSource>().isPlaying)
        {
            yield return null;
        }
        SceneManager.LoadScene("MainScene");
    }
}
