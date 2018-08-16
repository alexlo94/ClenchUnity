using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPanelBehavior : MonoBehaviour {
    public Vector3 GoalScale;
    public Vector3 SmallScale;

    public GameObject PlayerPanel;
    public GameObject Managers;

	// Use this for initialization
	void Start () {
        GoalScale = transform.localScale;
        //SmallScale = new Vector3(1.0f, 1.9f, 1.0f);
        SmallScale = GoalScale * 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MuscleFlexed()
    {
        Debug.Log("Muscle is flexed");
        if ((transform.localScale.x < GoalScale.x) && (transform.localScale.y < GoalScale.y))
        {
            this.transform.localScale *= 1.03f;
        }
        else
        {
            //play victory sound
            PlayerPanel.SetActive(true);
            Managers.SendMessage("WinnerDeclared");
        }
    }

    public void PoseProposed()
    {
        transform.localScale = SmallScale;
    }
    public void PoseCleared()
    {
        transform.localScale = GoalScale;
    }
}
