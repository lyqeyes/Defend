using UnityEngine;
using System.Collections;

public class playerAttack : MonoBehaviour 
{

	public float attackDist = 0.5f; 

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void DoDamage(int damage, float attackDist)
	{
		var colliders = Physics.OverlapSphere (this.transform.position, attackDist);

		foreach(var hit in colliders)
		{
			if(hit.gameObject.tag == "enemy")
			{
				var dir = (hit.transform.position - transform.position).normalized;
				var direction = Vector3.Dot(dir, transform.forward);
				if(direction < 0.5f)
					continue;

				CharacterStatus cs = hit.gameObject.transform.GetComponent<CharacterStatus>();

				cs.doDamage(damage);

			}


		}
	}

	public void skill1(int damage)
	{
		var colliders = Physics.OverlapSphere (this.transform.position, 1.3f);

		foreach(var hit in colliders)
		{
			if(hit.gameObject.tag == "enemy")
			{	
				CharacterStatus cs = hit.gameObject.transform.GetComponent<CharacterStatus>();
				
				cs.doDamage(damage);
				
			}
			
			
		}
	}
}
