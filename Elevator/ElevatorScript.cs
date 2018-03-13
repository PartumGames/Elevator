using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour {

	public GameObject elevatorPanel;

	enum EleStates{goUP, goDown, PauseState};
	EleStates states;

	public Transform top;
	public Transform bottom;

	public float smooth;

	Vector3 newPos;

	bool hasRider;

	void Start(){
		elevatorPanel.SetActive (false);
		states = EleStates.PauseState;
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.U) && hasRider) {
			states = EleStates.goUP;
		}

		if (Input.GetKeyDown (KeyCode.D) && hasRider) {
			states = EleStates.goDown;
		}

		FMS ();
	}

	void OnTriggerEnter(Collider coll){
		if (coll.tag == "Player") {
			elevatorPanel.SetActive (true);
			coll.transform.parent = gameObject.transform;
			hasRider = true;
		}
	}

	void OnTriggerExit(Collider coll){
		if (coll.tag == "Player") {
			elevatorPanel.SetActive (false);
			coll.transform.parent = null;
			hasRider = false;
		}
	}

	void FMS(){
		if (states == EleStates.goDown) {
			newPos = bottom.position;
			transform.position = Vector3.Lerp (transform.position, newPos, smooth * Time.deltaTime);
		}

		if (states == EleStates.goUP) {
			newPos = top.position;
			transform.position = Vector3.Lerp (transform.position, newPos, smooth * Time.deltaTime);
		}

		if (states == EleStates.PauseState) {
	
		}


	}

//end o class
}
