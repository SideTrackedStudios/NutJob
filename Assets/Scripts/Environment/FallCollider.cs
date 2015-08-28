using UnityEngine;
using System.Collections;

public class FallCollider : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player"){
			Application.LoadLevel(Application.loadedLevel);
		}
	}

}
