using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState<Bot>
{
	public void OnEnter(Bot t)
	{
		//wait - run animation
		//dung lai 1-5s
		t.changeAnim("idle");
		t.Counter.Start(() => t.ChangeState(new PatrolState()), Random.Range(1f, 3f));
	}
	public void OnExecute(Bot t)
	{
		t.Counter.Execute();
	}
	public void OnExit(Bot t)
	{
	}
}
