using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	//set these in the unity interface
	public Transform cameraHolder;
	public float cameraSpeed;
	public Transform player;
	//there are four camera movement types, set them in the unity interface
	public CameraMovementType cameraMovementType;


	void Start ()
	{
		//cameraHolder = Camera.main.transform.parent.transform;
	}

	void FixedUpdate ()
	{
		//call this on every frame to move the camera
		CameraMove ();
	}

	void CameraMove ()
	{
		switch (cameraMovementType) {
			case CameraMovementType.AccelDecel:
				cameraHolder.transform.position = InterpolationLibrary.AccelDecelInterpolation(cameraHolder.position, player.position, Time.deltaTime * cameraSpeed);
				break;
			case CameraMovementType.Acceleration:
				cameraHolder.transform.position = InterpolationLibrary.AccelerationInterpolation(cameraHolder.position, player.position, Time.deltaTime * cameraSpeed, 1);
				break;
			case CameraMovementType.Lerp:
				cameraHolder.transform.position = Vector2.Lerp (cameraHolder.transform.position, player.position, Time.deltaTime * cameraSpeed);
				break;
			case CameraMovementType.MoveTowards:
				cameraHolder.transform.position = Vector2.MoveTowards (cameraHolder.transform.position, player.position, Time.deltaTime * cameraSpeed);
				break;
			case CameraMovementType.Stopped:
			default:
				break;
		}
	}

	public enum CameraMovementType
	{
		AccelDecel,
		Acceleration,
		Lerp,
		MoveTowards,
		Stopped,
	}
}
