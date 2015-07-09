using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour
{

	private Animator _animator;

	private playerAttack player_attack;

	private CharacterController _character;

	private bool attack = true;

	private float LastTime ;

	public GameObject skillEffect;

	public float attacktime = 1.0f;

	public float speed = 3;

	public float gravity = 20;

	public GameObject sword;

	private Vector3 moveDirection;

	private int skill2Count = 0;


	void Start()
	{
		_animator = transform.GetComponent<Animator> ();
		player_attack = transform.GetComponent<playerAttack> ();
		_character = transform.GetComponent<CharacterController> ();

		LastTime = Time.time;
	}

	void Update()
	{
		if (!_character.isGrounded) 
		{

			_character.Move(new Vector3(0, -2,0));
		} 

	}

	void OnEnable()
	{

		EasyJoystick.On_JoystickMove += OnJoystickMove;
		EasyJoystick.On_JoystickMoveEnd += OnJoystickMoveEnd;
	}


	void OnJoystickMove(MovingJoystick move)
	{
		if (move.joystickName != "MoveJoystick") 
		{
			return;
		}

		float joyPositionX = move.joystickAxis.x;
		float joyPositionY = move.joystickAxis.y;

		if (joyPositionX != 0 || joyPositionY != 0) 
		{
			var dir = new Vector3(transform.position.x + joyPositionX, transform.position.y, transform.position.z + joyPositionY);

			transform.LookAt(dir);

			var newDir = (dir - transform.position).normalized;

			//transform.Translate(Vector3.forward * Time.deltaTime * 100 * speed);
			_character.Move(newDir * Time.deltaTime * 0.2f * speed);
		}

		_animator.SetBool("run", true);
	


	}

	void OnJoystickMoveEnd(MovingJoystick move)
	{
		if (move.joystickName == "MoveJoystick")
		{
			_animator.SetBool("run", false);
		}


	}

	void playSkill()
	{
		Instantiate (skillEffect, transform.position, Quaternion.identity);

		StartCoroutine (DPS());

	}

	void playSkill2()
	{
		skill2Count = 5;
		sword.transform.localScale = new Vector3 (5,5,5);
	}



	void shoot()
	{

		if (Time.time - LastTime > attacktime) 
		{
			LastTime = Time.time;
			float attDis = 0.5f;
			int damage = 50;
			if(skill2Count != 0)
			{
				attDis = 3;
				damage = 100;
				skill2Count--;
			}
			else
			{
				sword.transform.localScale = new Vector3(1,1,1);
			}

			player_attack.DoDamage (damage, attDis);
			
			if (attack) 
			{
				
				_animator.SetTrigger("attack1");
				attack = false;
				
			} 
			else 
			{
				_animator.SetTrigger("attack2");
				attack = true;
			}

		}


	}

	IEnumerator DPS()
	{
		int skillCount = 0;
		player_attack.skill1(30);
		while (skillCount < 3)
		{
			yield return new WaitForSeconds(1.0f);
			Debug.Log(skillCount);
			player_attack.skill1(50);
			skillCount++;
		}

	}
	

}

















