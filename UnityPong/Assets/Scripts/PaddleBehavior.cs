using UnityEngine;
using System.Collections;

public enum Player
{
	First = 0,
	Second = 1
}

public class PaddleBehavior : MonoBehaviour {

	public Player _player;
	public float _speed;
	public KeyCode GoUpKey;
	public KeyCode GoDownKey;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (GoUpKey)) {
			MoveUp();
		}
		if (Input.GetKey (GoDownKey)) {
			MoveDown();
		}
	}

	void MoveDown()
	{
		this.gameObject.transform.Translate (Vector3.back *  Time.deltaTime * _speed);
	}
	
	void MoveUp()
	{
		this.gameObject.transform.Translate (Vector3.forward *  Time.deltaTime * _speed);
	}
}
