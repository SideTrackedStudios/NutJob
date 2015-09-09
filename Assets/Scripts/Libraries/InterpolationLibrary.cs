using UnityEngine;
using System.Collections;

public class InterpolationLibrary : MonoBehaviour {

	public static Vector2 AccelDecelInterpolation(Vector2 start, Vector2 end, float t)
	{
		float x = end.x - start.x;
		float y = end.y - start.y;
		
		float newT = (Mathf.Cos ((t + 1) * Mathf.PI) / 2) + 0.5f;
		
		x *= newT;
		y *= newT;
		
		Vector2 retVector = new Vector2 (start.x + x, start.y + y);
		
		return retVector;
	}
	
	public static Vector2 AccelerationInterpolation(Vector2 start, Vector2 end, float t, float factor)
	{
		float x = end.x - start.x;
		float y = end.y - start.y;
		
		float newT = t;
		
		if (FloatEquals (factor, 1)) {
			newT *= newT;
		} else {
			
			Mathf.Pow(newT, 2 * factor);
		}
		
		x *= newT;
		y *= newT;
		
		Vector2 retVector = new Vector2 (start.x + x, start.y + y);
		
		return retVector;
		
	}
	
	private static bool FloatEquals(float f1, float f2)
	{
		return Mathf.Abs (f1 - f2) < 0.001f; //returns true/false based only if its more than 0.001f
		
	}
}
