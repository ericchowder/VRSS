using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightHandIndexInherit : MonoBehaviour {

	public GameObject palm;
	private rightHandGyro righthandgyro;
	
	public float RIX = 0, RIY = 0, RIZ = 0;

	void Awake () {
		Debug.Log("Awake RH index\n");
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
		RIX = righthandgyro.RIX;
		RIY = righthandgyro.RIY;
		RIZ = -(righthandgyro.RIZ);
		transform.rotation = Quaternion.Euler(RIX,RIZ,RIY);
	}
}
