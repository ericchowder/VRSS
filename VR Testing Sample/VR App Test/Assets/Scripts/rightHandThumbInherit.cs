using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightHandThumbInherit : MonoBehaviour {

	public GameObject palm;
	private rightHandGyro righthandgyro;

	public float RTX = 0, RTY = 0, RTZ = 0;

	void Awake () {
		Debug.Log("Awake RH thumb\n");
		palm = GameObject.Find("Cap1/right hand/Armature/wrist/palm");
		righthandgyro = palm.GetComponent<rightHandGyro>();
		//Debug.Log("Gets RIX val: {0}" + righthandgyro.RIX);

	}
	// Use this for initialization
	void Start () {

		//transform.Rotate(RIX * 0.01f, RIY * 0.01f, RIZ * 0.01f);

	}

	// Update is called once per frame
	void Update () {
		RTX = righthandgyro.RTX;
		RTY = righthandgyro.RTY;
		RTZ = -(righthandgyro.RTZ);
		transform.rotation = Quaternion.Euler(RTX, 0, RTY);
	}
}
