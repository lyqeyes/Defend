using UnityEngine;
using System.Collections;

public class enemyDied : CharacterDied 
{


	public override void Died()
	{
		Destroy (gameObject, 4);
		StartCoroutine (delayAnim("die"));
		GetComponent<CharacterController> ().enabled = false;
		GetComponent<Ai> ().enabled = false;
    }

	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator delayAnim(string animName)
	{
		yield return new WaitForSeconds (0.6f);
		
		_animator.SetTrigger (animName);
	}



}
