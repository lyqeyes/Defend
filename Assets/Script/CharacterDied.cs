using UnityEngine;
using System.Collections;

public class CharacterDied : MonoBehaviour 
{
	[HideInInspector]
	public Animator _animator;

	void Start () 
	{
		_animator = GetComponent<Animator> ();
	}

	public virtual void Died()
	{

	}



}
