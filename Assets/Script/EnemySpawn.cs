using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour 
{
	public List<GameObject> EnemyList;

	public float randX = 4;

	public float randZ = 4;


	// Use this for initialization
	void Start () 
	{
		StartCoroutine (spawnEnemy());
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}


	IEnumerator spawnEnemy()
	{

		int randx = Random.Range (0, EnemyList.Count);
		
		Instantiate (EnemyList [randx], transform.position, Quaternion.identity);

		while (true)
		{

			yield return new WaitForSeconds(20.0f);

			float rdX = Random.Range(-1*randX, randX);
			float rdZ = Random.Range(-1*randZ, randZ);

			randx = Random.Range (0, EnemyList.Count);
			
			Instantiate (EnemyList [randx], new Vector3(transform.position.x + rdX, transform.position.y, transform.position.z + rdZ),
			             Quaternion.identity);
		}


	}
}
