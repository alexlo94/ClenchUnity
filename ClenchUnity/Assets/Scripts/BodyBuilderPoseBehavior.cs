using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyBuilderPoseBehavior : MonoBehaviour {
    public Sprite[] BBPoses;
    public SpriteRenderer CurrentPose;


	// Use this for initialization
	void Start () {
        CurrentPose = this.gameObject.GetComponent<SpriteRenderer>();
        CurrentPose.sprite = BBPoses[0];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PoseProposed()
    {
        int randomInt = (int)Random.Range(1, BBPoses.Length);
        Debug.Log(randomInt);
        CurrentPose.sprite = BBPoses[randomInt];
    }
    public void PoseCleared()
    {
        CurrentPose.sprite = BBPoses[0];
    }
}
