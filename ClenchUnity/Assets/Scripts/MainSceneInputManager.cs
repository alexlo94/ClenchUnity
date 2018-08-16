using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneInputManager : MonoBehaviour {
    public bool Player1OnMat = false;
    public bool Player2OnMat = false;
    public bool PoseProposed = false;
    public GameObject BBPose;

    public GameObject Player1Panel;
    public GameObject Player2Panel;

    public AudioSource Background;
    public AudioSource Reaction;
    public AudioSource NamePlates;

    public AudioClip[] BGTracks;
    public AudioClip ReactionSound;


	// Use this for initialization
	void Start () {
        Player1Panel = GameObject.Find("Player1Panel");
        Player2Panel = GameObject.Find("Player2Panel");

        Background = GameObject.Find("Background").GetComponent<AudioSource>();
        Reaction = gameObject.GetComponent<AudioSource>();
        NamePlates = GameObject.Find("NamePlates").GetComponent<AudioSource>();

        Background.clip = BGTracks[0];
        Background.Play();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            gameObject.GetComponent<WebcamInputManager>().Player1Feed.Play();
            gameObject.GetComponent<WebcamInputManager>().Player2Feed.Play();
            if(Background.clip != BGTracks[1])
            {
                Background.clip = BGTracks[1];
                Background.Play();
            }

            if (!Reaction.isPlaying)
            {
                Reaction.Play();
            }

            PoseProposed = true;
            Player1OnMat = false;
            Player2OnMat = false;
            BBPose.SendMessage("PoseProposed");
            Player1Panel.SendMessage("PoseProposed");
            Player2Panel.SendMessage("PoseProposed");
            Player1Panel.GetComponent<PlayerPanelBehavior>().PlayerPanel.SetActive(false);
            Player2Panel.GetComponent<PlayerPanelBehavior>().PlayerPanel.SetActive(false);
        }
        if (Input.GetKeyDown("escape"))
        {
            gameObject.GetComponent<WebcamInputManager>().Player1Feed.Play();
            gameObject.GetComponent<WebcamInputManager>().Player2Feed.Play();
            if (Background.clip != BGTracks[0])
            {
                Background.clip = BGTracks[0];
                Background.Play();
            }

            if (!Reaction.isPlaying)
            {
                Reaction.Play();
            }

            PoseProposed = false;
            Player1OnMat = false;
            Player2OnMat = false;
            BBPose.SendMessage("PoseCleared");
            Player1Panel.SendMessage("PoseCleared");
            Player2Panel.SendMessage("PoseCleared");
            Player1Panel.GetComponent<PlayerPanelBehavior>().PlayerPanel.SetActive(false);
            Player2Panel.GetComponent<PlayerPanelBehavior>().PlayerPanel.SetActive(false);
        }

        if((Input.GetKeyDown("q")) && PoseProposed && Player1OnMat && Player2OnMat)
        {
            Player1Panel.SendMessage("MuscleFlexed");
        }
        if((Input.GetKeyDown("e")) && PoseProposed && Player1OnMat && Player2OnMat)
        {
            Player2Panel.SendMessage("MuscleFlexed");
        }

        if (Input.GetKeyDown("w"))
        {
            Player1OnMat = true;
        }
        if (Input.GetKeyDown("r"))
        {
            Player2OnMat = true;
        }
		
	}

    public void WinnerDeclared()
    {
        PoseProposed = false;
        if (!NamePlates.isPlaying)
        {
            Background.Stop();
            Background.clip = null;
            NamePlates.Play();
        }
    }
}
