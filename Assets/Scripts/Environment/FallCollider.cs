using UnityEngine;
using System.Collections;

public class FallCollider : MonoBehaviour {

	private GameObject player;
	private GameObject mainCamera;
	private CameraMovement movement;
	private CameraMovement.CameraMovementType origCameraType;
	private bool hasTriggered = false;

	void OnTriggerEnter2D(Collider2D collider)
	{
		player = GameObject.Find("Player");
		mainCamera = GameObject.Find("Main Camera");
		movement = mainCamera.GetComponent<CameraMovement>();

		if (!hasTriggered && collider.gameObject.Equals(player))
		{
			Debug.Log("player fell to his demise");

			hasTriggered = true;
			StopCamera ();
			Invoke ("ReloadLevel", 1.5f);  // delayed method call
		}
	}

	private void StopCamera()
	{
		// save the current camera movement type
		origCameraType = movement.cameraMovementType;
		// temporarily halt camera movement
		movement.cameraMovementType = CameraMovement.CameraMovementType.Stopped;
	}

	private void ReloadLevel()
	{
		// restore camera movement type
		movement.cameraMovementType = origCameraType;
		// reload the current level
		Application.LoadLevel(Application.loadedLevel);
	}

}
