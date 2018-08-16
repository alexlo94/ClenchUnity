using UnityEngine;
using System.IO.Ports;

public class SerialInputManager : MonoBehaviour {
    SerialPort Player1Input;
    SerialPort Player2Input;

	// Use this for initialization
	void Start () {

        Player1Input = new SerialPort("COM3", 9600);
        Player2Input = new SerialPort("COM5", 9600);

        Player1Input.Open();
        Player2Input.Open();
		
	}

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Player 1 is reading: " + Player1Input.ReadLine() + "," + " Player 2 is reading: " + Player2Input.ReadLine());
    }
}
