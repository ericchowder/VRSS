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

public class leftHandGyro : MonoBehaviour
{
	SerialPort sp = new SerialPort("COM4", 9600);

	public float speed;
	private float amountToMove;

	public float RIX = 0, RIY = 0, RIZ = 0, RTX = 0, RTY = 0, RTZ = 0, RHX = 0, RHY = 0, RHZ = 0, LIX = 0, LIY = 0, LIZ = 0, LTX = 0, LTY = 0, LTZ = 0, LHX = 0, LHY = 0, LHZ = 0;
	void Start()
	{
		Debug.Log("Start LH gyro\n");
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
				LIX = gyroVals[0]; // Accel RIX
				LIZ = -gyroVals[1]; // Accel RIY
				LIY = -gyroVals[2]; // Accel RIZ
				LTX = gyroVals[3]; // Accel RTX
				LTZ = -gyroVals[4]; // Accel RTY
				LTY = -gyroVals[5]; // Accel RTZ
				LHZ = -gyroVals[6]; // Gyro RHX
				LHX = -gyroVals[7]; // Gyro RHY
				LHY = -gyroVals[8]; // Gyro RHZ
				*/
				//Debug.LogFormat("time: {0}", Time.fixedDeltaTime);
				//Debug.LogFormat("LIX: {0} LIY: {1} LIZ: {2} LTX: {3} LTY: {4} LTZ: {5} LHX: {6} LHY: {7} LHZ: {8}", LIX, LIY, LIZ, LTX, LTY, LTZ, LHX, LHY, LHZ);
				// --- ACCELEROMETER IS FLIPPED ---
				// Unity: X = L/R, Z = F/B, Y = U/D
				// Accel: X = L/R, Y = F/B, Z = U/D (Y & Z are flipped)
				// uX = aX, uZ = -aY, uY = -aZ
				// --- GYROSCOPE IS ALSO FLIPPED (acclerometer values on gyroscope) ---
				// Gyro: X = F/B, Y = L/R, Z = U/D (X, Y, & Z are flipped)
				// uX = -gY, uY = -gZ, uZ = -gX
				
				LIX = gyroVals[0];
				LIY = gyroVals[1];
				LIZ = gyroVals[2];
				LTX = gyroVals[3];
				LTY = gyroVals[4];
				LTZ = gyroVals[5];
				LHX = -gyroVals[6];
				LHY = gyroVals[7];
				LHZ = gyroVals[8];
				
				//print("SP ReadExisting() test: " + sp.ReadExisting() + "\n");
				//print("SP ReadExisting() test: " + sp.ReadChar() + "\n");
				//print("testing: " + sp.ReadLine());
			}
			catch (System.Exception)
			{
			}
		}
		transform.rotation = Quaternion.Euler(LHY, LHZ, LHX);
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