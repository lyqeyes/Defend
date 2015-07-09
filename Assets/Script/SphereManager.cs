using UnityEngine;
using System.Collections;

public class SphereManager : MonoBehaviour
{

	public GameObject Sphere;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine (SphereBorn());
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}


	IEnumerator SphereBorn()
	{

		while (true)
		{
			yield return new WaitForSeconds (4.0f);
			
			Instantiate (Sphere, Sphere.transform.position, Quaternion.identity);
		}
	
	}
}
