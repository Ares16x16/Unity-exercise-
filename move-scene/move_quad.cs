using UnityEngine;
using System.Collections;

public class move_quad : MonoBehaviour 
{
	public float scrollSpeed;
	public float tileSizeY;
	
	private Vector2 startPosition;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeY);
		transform.position = startPosition + Vector2.up * newPosition;
	}
}

