using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebcamInputManager : MonoBehaviour {

    public WebCamTexture Player1Feed;
    public WebCamTexture Player2Feed;

	// Use this for initialization
	void Start () {
        WebCamDevice[] devices = WebCamTexture.devices;
        Shader Unlit = Shader.Find("Unlit/Texture");

        for(int i = 0; i < devices.Length; i++)
        {
            print("Webcam available: " + devices[i].name);
        }

        Renderer Player1Rend = GameObject.Find("Player1Panel").GetComponentInChildren<Renderer>();
        Renderer Player2Rend = GameObject.Find("Player2Panel").GetComponentInChildren<Renderer>();

        Player1Feed = new WebCamTexture(devices[0].name);
        Player2Feed = new WebCamTexture(devices[0].name); //change this to devices[1] when we have a second webcam

        Player1Rend.material.mainTexture = Player2Feed;
        Player2Rend.material.mainTexture = Player1Feed;

        Player1Rend.material.shader = Unlit;
        Player2Rend.material.shader = Unlit;

        Player1Feed.Play();
        Player2Feed.Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void WinnerDeclared()
    {
        Player1Feed.Stop();
        Player2Feed.Stop();
    }
}
