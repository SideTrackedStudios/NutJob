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
		cameraHolder = Camera.main.transform.parent.transform;
	}

	void FixedUpdate ()
	{
		//call this on every frame to move the camera
		CameraMove ();
	}

	void CameraMove ()
	{
		switch (cameraMovementType) {
		case CameraMovementType.Lerp:
			cameraHolder.transform.position = Vector3.Lerp (cameraHolder.transform.position, player.position, Time.deltaTime * cameraSpeed);
			break;
		case CameraMovementType.MoveTowards:
			cameraHolder.transform.position = Vector3.MoveTowards (cameraHolder.transform.position, player.position, Time.deltaTime * cameraSpeed);
			break;
		case CameraMovementType.AccelDecel:
			cameraHolder.transform.position = InterpilationLibrary.AccelDecelInterpolation(cameraHolder.position, player.position, Time.deltaTime * cameraSpeed);
			break;
		case CameraMovementType.Accerleration:
			cameraHolder.transform.position = InterpilationLibrary.AccelerationInterpolation(cameraHolder.position, player.position, Time.deltaTime * cameraSpeed, 1);
			break;
			
		}
	}

	public enum CameraMovementType
	{
		Lerp,
		MoveTowards,
		AccelDecel,
		Accerleration
	}
}
