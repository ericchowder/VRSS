using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftHandIndexInherit : MonoBehaviour {

	public GameObject palm;
	private leftHandGyro lighthandgyro;
	
	public float LIX = 0, LIY = 0, LIZ = 0;

	void Awake () {
		Debug.Log("Awake LH index\n");
		palm = GameObject.Find("Cap1/left hand/Armature/wrist/palm");
		lighthandgyro = palm.GetComponent<leftHandGyro>();
		//Debug.Log("Gets RIX val: {0}" + righthandgyro.RIX);
	}

	// Use this for initialization
	void Start () {
		//transform.Rotate(RIX * 0.01f, RIY * 0.01f, RIZ * 0.01f);
	}
	
	// Update is called once per frame
	void Update () {
		LIX = lighthandgyro.LIX;
		LIY = lighthandgyro.LIY;
		LIZ = lighthandgyro.LIZ;
		transform.rotation = Quaternion.Euler(LIX, LIY, LIZ);
	}
}
