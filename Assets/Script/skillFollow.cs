using UnityEngine;
using System.Collections;

public class skillFollow : MonoBehaviour 
{

	private GameObject player;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find ("player");
		Destroy (this.gameObject, 4);
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = player.transform.position;
	
	}
}
