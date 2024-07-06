using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float moveSpeed = 5f;

    private CounterTime counter = new CounterTime();
    // Start is called before the first frame update
    void Start()
	{
        OnInit();
	}
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            counter.Cancel();
        }
        if (Input.GetMouseButton(0) && JoyStickController.direct != Vector3.zero)
        {
            rb.MovePosition(rb.position + JoyStickController.direct * moveSpeed * Time.deltaTime);
            transform.position = rb.position;
            transform.forward = JoyStickController.direct;
            changeAnim("run");
        }
        else
        {
            counter.Execute();
        }
        if (Input.GetMouseButtonUp(0))
        {
            Character target = GetTargetInRange();
            if (target != null)
            {
                changeAnim("attack");
                OnAttack();
			}
            else 
            {
                changeAnim("idle");
            }
        }
    }
	public override void OnInit()
	{
		base.OnInit();
	}
	public override void OnAttack()
	{
		base.OnAttack();
        counter.Start(Throw, 0.5f);
        //changeAnim("idle");
	}
	public override void OnDeath()
	{
        //main menu
		base.OnDeath();
	}

}
