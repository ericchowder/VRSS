using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/*
public class SerialTest : MonoBehaviour {


}

 using UnityEngine;
 using System.Collections;
 */
 using System.IO.Ports;

public class rightHandGyro : MonoBehaviour
{
	SerialPort sp = new SerialPort("COM3", 9600);

	public float speed;
	private float amountToMove;

	public float RIX = 0, RIY = 0, RIZ = 0, RTX = 0, RTY = 0, RTZ = 0, RHX = 0, RHY = 0, RHZ = 0, LIX = 0, LIY = 0, LIZ = 0, LTX = 0, LTY = 0, LTZ = 0, LHX = 0, LHY = 0, LHZ = 0;
	void Start()
	{
		Debug.Log("Start RH gyro\n");
		sp.Open();
		sp.ReadTimeout = 20;
	}
	
	void Update()
	{

		/* TESTING SERIAL VALUEs 
		try
		{
			print(sp.ReadLine());
		}
		catch (System.Exception)
		{
		}
		*/
		amountToMove = speed * Time.deltaTime;

		if (sp.IsOpen)
		{
			try
			{
				//testMovement(sp.ReadByte());
				//MessageReceived(sp.ReadLine());
				float[] gyroVals = SerialToFloats(sp.ReadLine());
				/*
				RIX = gyroVals[0]; // Accel RIX
				RIZ = -gyroVals[1]; // Accel RIY
				RIY = -gyroVals[2]; // Accel RIZ
				RTX = gyroVals[3]; // Accel RTX
				RTZ = -gyroVals[4]; // Accel RTY
				RTY = -gyroVals[5]; // Accel RTZ
				RHZ = -gyroVals[6]; // Gyro RHX 
				RHX = -gyroVals[7]; // Gyro RHY
				RHY = -gyroVals[8]; // Gyro RHZ
				*/
				RIX = gyroVals[0]; // Accel RIX 
				RIY = gyroVals[1]; // Accel RIY
				RIZ = gyroVals[2]; // Accel RIZ
				RTX = gyroVals[3]; // Accel RTX
				RTY = gyroVals[4]; // Accel RTY
				RTZ = gyroVals[5]; // Accel RTZ
				RHX = -gyroVals[6]; // Gyro RHX //This is -RHZ
				RHY = gyroVals[7]; // Gyro RHY //This is RHY
				RHZ = gyroVals[8]; // Gyro RHZ //This is RHX
				//Debug.LogFormat("time: {0}", Time.fixedDeltaTime);
				//Debug.LogFormat("RHX: {0} RHY: {1} RHZ: {2}", RHX, RHY, RHZ);
				// --- ACCELEROMETER IS FLIPPED ---
				// Unity: X = L/R, Z = F/B, Y = U/D
				// Accel: X = L/R, Y = F/B, Z = U/D (Y & Z are flipped)
				// uX = aX, uZ = -aY, uY = -aZ
				// --- GYROSCOPE IS ALSO FLIPPED (acclerometer values on gyroscope) ---
				// Gyro: X = F/B, Y = L/R, Z = U/D (X, Y, & Z are flipped)
				// uX = -gY, uY = -gZ, uZ = -gX
				/*
				LIX = gyroVals[9];
				LIY = gyroVals[10];
				LIZ = gyroVals[11];
				LTX = gyroVals[12];
				LTY = gyroVals[13];
				LTZ = gyroVals[14];
				LHX = gyroVals[15];
				LHY = gyroVals[16];
				LHZ = gyroVals[17];
				*/
				//print("SP ReadExisting() test: " + sp.ReadExisting() + "\n");
				//print("SP ReadExisting() test: " + sp.ReadChar() + "\n");
				//print("testing: " + sp.ReadLine());
			}
			catch (System.Exception)
			{
			}
		}
		//transform.localEulerAngles = new Vector3(RHX, RHY, RHZ);
		transform.rotation = Quaternion.Euler(RHY ,RHZ, RHX);
		//transform.Translate(RHX, RHY, RHZ);
		Debug.LogFormat("Linein:{0}", sp.ReadLine());
	}
	
	void MessageReceived (string message)
		{
			var type = message[0];
			var value = float.Parse(message.Substring(1));
			switch (type)
			{
				case 'C':
					print(value);
					break;
				default:
					print("Invalid");
						break;
			}
		}
	
	float[] SerialToFloats(string message)
	{
		string[] separatedMessage = message.Split(',');
		float[] separatedValues = new float[separatedMessage.Length]; 
		for (int i = 0; i < separatedMessage.Length; i++)
		{
			separatedValues[i] = float.Parse(separatedMessage[i]);
		}
		return separatedValues;
	}
	
	void testMovement(int Direction)
	{
		if (Direction >= 0)
		{
			transform.Translate(Vector3.left * amountToMove, Space.Self);
			Debug.LogFormat("transform left test = {0} Readline Val = {1} Readbyte Val = {2}", amountToMove * -1, sp.ReadLine(), sp.ReadByte());
		}
		if (Direction < 0)
		{
			transform.Translate(Vector3.right * amountToMove, Space.Self);
			Debug.LogFormat("transform right test: {0} Readline Val = {1} Readbyte Val = {2}", amountToMove, sp.ReadLine(), sp.ReadByte());
		}
	}
	
}