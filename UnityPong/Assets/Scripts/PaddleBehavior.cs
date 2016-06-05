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
	public GameObject TopBar;
	public GameObject BottomBar;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (GoUpKey) && CanGoUp()) {
			MoveUp();
		}
		if (Input.GetKey (GoDownKey) && CanGoDown()) {
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

	bool CanGoUp()
	{
		return TopBar.transform.position.z - (TopBar.transform.localScale.z / 2f) > gameObject.transform.position.z + (gameObject.transform.localScale.z / 2f);
	}

	bool CanGoDown()
	{	
		return BottomBar.transform.position.z + (BottomBar.transform.localScale.z / 2f) < gameObject.transform.position.z - (gameObject.transform.localScale.z / 2f);
	}
}
