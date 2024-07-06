using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : Character
{
	public NavMeshAgent agent;
	private Vector3 destination;
	public bool IsDestintion =>(Mathf.Abs(destination.x - transform.position.x) + Mathf.Abs(destination.z - transform.position.z)) < 0.5f;
	private CounterTime counter = new CounterTime();
	public CounterTime Counter =>counter;
	public bool isDead = false;
	void Start()
	{
		ChangeState(new PatrolState());
		OnInit();
	}
	public void SetDestination(Vector3 position)
	{
		agent.enabled = true;
		destination = position;
		destination.y = 0f;
		agent.SetDestination(position);
	}
	IState<Bot> currentState;
	private void Update()
	{
		if (currentState != null)
		{
			currentState.OnExecute(this);
		}
		counter.Execute();
	}
	public void ChangeState(IState<Bot> state)
	{
		if (!isDead)
		{
			if (currentState != null)
			{
				currentState.OnExit(this);
			}
			currentState = state;
			if (currentState != null)
			{
				currentState.OnEnter(this);
			}
		}
	}
	public override void OnDeath()
	{
		//Debug.Log(" bot dead");
		isDead = true;
		base.OnDeath();
		ChangeState(null);
		//cho bot k troi di
		agent.enabled = false;
		Invoke(nameof(disableSelf), 2f);
	}
	private void disableSelf()
	{
		gameObject.SetActive(false);
	}
	public override void OnAttack()
	{
		base.OnAttack();
		target = GetTargetInRange();
		changeAnim("attack");
		counter.Start(Throw, 0.5f);
	}
	public void OnMoveStop()
	{
		agent.enabled = false;
		changeAnim("idle");
	}
	public override void AddTarget(Character target)
	{
		base.AddTarget(target);
		if (Random.Range(0, 2) == 0 && Camera.main.WorldToViewportPoint(transform.position).x < 1f && Camera.main.WorldToViewportPoint(transform.position).y < 1f )
        {
			ChangeState(new AttackState());
			Invoke(nameof(ChangeStateAfterAttack), 1f);
		}
	}
	public override void OnInit()
	{
		base.OnInit();
	}
	private void ChangeStateAfterAttack()
	{
		if (!isDead)
		{
			if (Random.Range(0, 2) == 0)
			{
				ChangeState(new IdleState());
			}
			else
			{
				ChangeState(new PatrolState());
			}
		}
	}
}
