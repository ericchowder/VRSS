using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftHandThumbInherit : MonoBehaviour {

	public GameObject palm;
	private leftHandGyro lighthandgyro;

	public float LTX = 0, LTY = 0, LTZ = 0;

	void Awake()
	{
		Debug.Log("Awake LH thumb\n");
		palm = GameObject.Find("Cap1/left hand/Armature/wrist/palm");
		lighthandgyro = palm.GetComponent<leftHandGyro>();
		//Debug.Log("Gets RIX val: {0}" + righthandgyro.RIX);

	}
	// Use this for initialization
	void Start()
	{
		//transform.Rotate(RIX * 0.01f, RIY * 0.01f, RIZ * 0.01f);

	}

	// Update is called once per frame
	void Update()
	{
		LTX = lighthandgyro.LIX;
		LTY = lighthandgyro.LIY;
		LTZ = lighthandgyro.LIZ;
		//transform.Rotate(LTX, LTY, LTZ);
	}
}
