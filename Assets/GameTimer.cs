using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {
	private enum States {Stopped, Running, Done};
	private States state = States.Stopped;
	private Text text;
	private int msPassed;

	// Use this for initialization
	void Start () {
		text = this.GetComponent<Text> ();
		msPassed = 0;
	}

	public void StateRun () {
		if (state != States.Stopped)
			return;
		state = States.Running;
	}

	public void StateDone () {
		if (state != States.Running)
			return;
		state = States.Done;
	}
	
	// Update is called once per frame
	void Update () {
		if (state != States.Running) {
			return;
		}
		msPassed += (int) (1000.0 * Time.deltaTime);
		UpdateLabel ();
	}

	void UpdateLabel ()
	{
		int secondsPassed = msPassed / 1000;
		int hundredsPassed = (msPassed % 1000) / 10;
		text.text = ZeroPad (secondsPassed) + ":" + ZeroPad (hundredsPassed);
	}

	private string ZeroPad(int number) {
		string result = number.ToString ();
		if (number < 10) {
			result = "0" + result;
		}
		return result;
	}
}
