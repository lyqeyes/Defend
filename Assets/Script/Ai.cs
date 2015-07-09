using UnityEngine;
using System.Collections;

public enum EnemyType
{
	Enemy0,
	Enemy1
}

public class Ai : MonoBehaviour 
{

	public EnemyType enemyType = EnemyType.Enemy0;

	public float speed = 1;

	public float attackDistance = 0.4f;

	public float attackVal = 2.0f;

	private Transform player;

	public Transform tower;

	private Animator _animator;

	private const int ENEMY_NORMAL = 0;
	private const int ENEMY_ROTATION = 1;
	private const int ENEMY_RUN = 2;
	private const int ENEMY_CHASE = 3;
	private const int ENEMY_ATTACK = 4;

	private int state;
	private int rotation_state;
	private float aiThankLastTime;



	private CharacterController _character;


	// Use this for initialization
	void Start () 
	{
		state = ENEMY_NORMAL;

		_animator = transform.GetComponent<Animator> ();

		player = GameObject.Find ("player").transform;

		tower = GameObject.Find ("ImageTarget").transform.FindChild ("tower");

		_character = transform.GetComponent<CharacterController> ();

		aiThankLastTime = Time.time;

	}
	
	// Update is called once per frame
	void Update () 
	{
		switch (enemyType)
		{
		case EnemyType.Enemy0:
			updateEnemyType0();
			break;
		case EnemyType.Enemy1:
			updateEnemyType1();
			break;
		}


		if (!_character.isGrounded) 
		{
			
			_character.Move(new Vector3(0, -2,0));
		} 

	
	}

	void updateEnemyType0()
	{
		if (Vector3.Distance (player.transform.position, this.transform.position) <= 1000) 
		{
			this.transform.LookAt(player.transform);
		
		}
	}

	void updateEnemyType1()
	{
			UpdateEnemyState();
	}



	void UpdateEnemyState()	
	{
		state = ENEMY_NORMAL;

		float distance = Vector3.Distance(player.transform.position, this.transform.position);
		float distance2 = Vector3.Distance (tower.transform.position, this.transform.position);

		float dis = 0;

		Transform tran = player;

		float towdis = 0;

		if(distance < distance2 + 0.6)
		{
			dis = distance;
			tran = player;
		}
		else
		{
			dis = distance2;
			tran = tower;
			towdis = 0.3f;
		}

		if (dis <= attackDistance + towdis) 
		{
			if(Time.time - aiThankLastTime >= attackVal)
			{
				aiThankLastTime = Time.time;

				state = ENEMY_ATTACK;
			}
			else
			{
				state = ENEMY_NORMAL;
			}

		}
		else
		{
			state = ENEMY_CHASE;
		}


		var dir = (tran.position - transform.position).normalized;

		switch (state)
		{

		case ENEMY_NORMAL:
			this.transform.LookAt(tran);
			_animator.SetBool("attack", false);
			break;
		case ENEMY_CHASE:
			this.transform.LookAt(tran);
			_character.Move(dir * speed * 0.003f);
			_animator.SetBool("attack", false);
			aiThankLastTime = Time.time;
			break;

		case ENEMY_ATTACK:
			this.transform.LookAt(tran);
			_animator.SetBool("attack", true);
			break;
		}


	}



}










































