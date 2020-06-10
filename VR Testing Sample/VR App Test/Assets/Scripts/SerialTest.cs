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

public class SerialTest : MonoBehaviour
{
	SerialPort sp = new SerialPort("COM3", 9600);

	public float speed;
	private float amountToMove;

	double RIX = 0, RIY = 0, RIZ = 0, RTX = 0, RTY = 0, RTZ = 0, RHX = 0, RHY = 0, RHZ = 0, LIX = 0, LIY = 0, LIZ = 0, LTX = 0, LTY = 0, LTZ = 0, LHX = 0, LHY = 0, LHZ = 0;
	void Start()
	{
		sp.Open();
		sp.ReadTimeout = 1;
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
				double[] gyroVals = SerialToDoubles(sp.ReadLine());

				RIX = gyroVals[0];
				RIY = gyroVals[1];
				RIZ = gyroVals[2];
				RTX = gyroVals[3];
				RTY = gyroVals[4];
				RTZ = gyroVals[5];
				RHX = gyroVals[6];
				RHY = gyroVals[7];
				RHZ = gyroVals[8];
				//Debug.LogFormat("time: {0}", Time.fixedDeltaTime);
				Debug.LogFormat("RIX: {0} RIY: {1} RIZ: {2} RTX: {3} RTY: {4} RTZ: {5} RHX: {6} RHY: {7} RHZ: {8}", RIX, RIY, RIZ, RTX, RTY, RTZ, RHX, RHY, RHZ);
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

	double[] SerialToDoubles(string message)
	{
		string[] separatedMessage = message.Split(',');
		double[] separatedValues = new double[separatedMessage.Length]; 
		for (int i = 0; i < separatedMessage.Length; i++)
		{
			separatedValues[i] = Convert.ToDouble(separatedMessage[i]);
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