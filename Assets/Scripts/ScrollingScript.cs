using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScrollingScript : MonoBehaviour{
	public Vector2 speed = new Vector2(10, 10);
	public Vector2 direction = new Vector2(-1, 0);
	public bool isLinkedToCamera = false;
	public bool isLooping = false;

	private List<Transform> backgroundPart;

	void Start(){
		if (isLooping){
			backgroundPart = new List<Transform>();

			for (int i = 0; i < transform.childCount; i++){
				Transform child = transform.GetChild(i);

				// Only visible children
				if (child.GetComponent<Renderer>() != null){
					backgroundPart.Add(child);
				}
			}

			if (backgroundPart.Count == 0){
				Debug.LogError("Nothing to scroll!");
			}

			// Sort by position 
			// -- Depends on the scrolling direction
			backgroundPart = backgroundPart.OrderBy(t => t.position.x).ToList();

			// Get the size of the repeatable parts
			var first = backgroundPart.First();
			var last = backgroundPart.Last();
		}
	}

	void Update(){
		// Movement
		Vector3 movement = new Vector3(
			speed.x * direction.x,
			speed.y * direction.y,
			0);

		movement *= Time.deltaTime;
		transform.Translate(movement);

		// Move the camera
		if (isLinkedToCamera){
			Camera.main.transform.Translate(movement);
		}

		// Loop
		if (isLooping){
			// Get the first object
			Transform firstChild = backgroundPart.FirstOrDefault();

			if (firstChild != null){
				

				// Check if the sprite is really visible on the camera or not
				if (firstChild.position.x < Camera.main.transform.position.x){
					if (firstChild.GetComponent<Renderer>().IsVisibleFrom(Camera.main) == false){
						Transform lastChild = backgroundPart.LastOrDefault ();
						Vector3 lastPosition = lastChild.transform.position;
						Vector3 lastSize = lastChild.GetComponent<Renderer> ().bounds.max - lastChild.GetComponent<Renderer> ().bounds.min;


						// Set position in the end
						firstChild.position = new Vector3(lastPosition.x + lastSize.x, firstChild.position.y, firstChild.position.z						);

						// The first part become the last one
						backgroundPart.Remove(firstChild);
						backgroundPart.Add(firstChild);
					}
				}
			}

		}
	}
}