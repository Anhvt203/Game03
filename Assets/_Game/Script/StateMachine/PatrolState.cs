using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState<Bot>
{
	int targetBrick;
	public void OnEnter(Bot t)
	{
		t.changeAnim("run");
		SeekTarget(t);
	}
	public void OnExecute(Bot t)
	{
        if (t.IsDestintion)
        {
			t.ChangeState(new IdleState());
        }
    }
	public void OnExit(Bot t) { }
	private void SeekTarget(Bot t)
	{
		t.SetDestination(new Vector3(Random.Range(-150f, 150f), 0.5f, Random.Range(-150f, 150f)));
	}
}
