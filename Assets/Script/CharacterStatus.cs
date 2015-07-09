using UnityEngine;
using System.Collections;

public class CharacterStatus : DamageManager
{

	public int HP = 100;

	public float pushPower = 0.2f;

	private Animator _animator;

	void Start()
	{
		_animator = transform.GetComponent<Animator> ();
	}

	public override int doDamage(int damage)
	{

		HP -= damage;

		if (HP <= 0)
		{
			Die();

			return 0;
		}

		StartCoroutine(delayAnim("hit"));

		return HP;
	}

	void Die()
	{
		var characterDied = GetComponent<CharacterDied> ();
		characterDied.Died ();
	}

	IEnumerator delayAnim(string animName)
	{
		yield return new WaitForSeconds (0.6f);
		
		_animator.SetTrigger (animName);
	}



	void OnControllerColliderHit (ControllerColliderHit hit)// Character can push an object.
	{
		var body = hit.collider.attachedRigidbody;
		if (body == null || body.isKinematic) {
			return;
		}
		if (hit.moveDirection.y < -0.3) {
			return;
		}
		
		var pushDir = Vector3.Scale (hit.moveDirection, new Vector3 (1, 0, 1));
		body.velocity = pushDir * pushPower;
		
		Debug.Log(hit.gameObject.name);
	}





}
