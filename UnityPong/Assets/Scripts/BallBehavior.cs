using UnityEngine;
using System.Collections;

public class BallBehavior : MonoBehaviour {

	public float _speed;

	private bool _started;
	private Vector3 _startPosition;
	private Rigidbody _rigidbody;

	// Use this for initialization
	void Start () 
	{
		_rigidbody = GetComponent<Rigidbody> ();
		_startPosition = gameObject.transform.position;
		_rigidbody.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!_started && Input.GetKeyDown (KeyCode.Space)) 
		{
			var top = NextBoolean();
			var left = NextBoolean();

			var direction = new Vector3(left ? -1f : 1f, 0f, top ? 1f : -1f);
			_rigidbody.velocity = direction * _speed;

			_rigidbody.freezeRotation = false;
			_rigidbody.rotation = Random.rotation;

			_started = true;
		}
	}

	void OnCollisionEnter (Collision collission)
	{
		if (collission.gameObject.name == "Left" || collission.gameObject.name == "Right") 
		{
			_started = false;
			_rigidbody.freezeRotation = true;
			_rigidbody.velocity = new Vector3 (0f, 0f, 0f);
			gameObject.transform.position = _startPosition;

		} 
		else if (collission.gameObject.name == "Top") 
		{
			var left = _rigidbody.velocity.x < 0;
			var direction = new Vector3(left ? -1f : 1f, _rigidbody.velocity.y, -1f);
			_rigidbody.velocity = direction * _speed;
		}
		else if (collission.gameObject.name == "Bottom") 
		{
			var left = _rigidbody.velocity.x < 0;
			var direction = new Vector3(left ? -1f : 1f, _rigidbody.velocity.y, 1f);
			_rigidbody.velocity = direction * _speed;
		}
	}

	bool NextBoolean()
	{
		return Random.value >= 0.5;
	}
}
