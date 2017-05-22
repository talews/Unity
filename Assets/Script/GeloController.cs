using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeloController : MonoBehaviour {
	public Rigidbody2D rb;
	public float velocity;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		Destroy (this, 4);
	}
	
	// Update is called once per frame
	void Update () {
		movimentation ();
	}

	void movimentation ()
	{
		rb.position -= new Vector2 (velocity, 0);

	}
}
