using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : AbsCharacter
{
	public Animator animator;
	private string crrAnim;
	public Transform body;
	private int score = 1;
	public LayerMask groundLayer;
	//de public no hien
	protected Character target;
	protected TargetIndicator targetIndicator;
	[SerializeField] GameObject bulletPrefabs;
	[SerializeField] GameObject weapon;
	[SerializeField] GameObject indicatorPoint;
	public List<Character> targets = new List<Character>();

	// Start is called before the first frame update
	void Start()
    {

	}
	public void Throw()
	{
		GetTargetInRange();
		if (target != null)
		{
			//Debug.Log(target);
			Bullet bullet = Instantiate(bulletPrefabs, transform.position, Quaternion.identity).GetComponent<Bullet>();
			bullet.OnInit(this, target.transform);
			weapon.GetComponent<Weapon>().Throw();
		}
		else
		{
			OnAttack();
		}
	}
	public bool CanMove(Vector3 point)
	{
		bool canMove = true;
		return canMove;
	}
	public void UpdatePoints()
	{
		score++;
		targetIndicator.SetScore(score);
		body.localScale = new Vector3(7f + (score -1)* 0.5f, 7f + (score - 1) * 0.5f, 7f + (score - 1) * 0.5f);
	}
	public virtual void changeAnim(string animName)
	{
		if (!string.IsNullOrEmpty(crrAnim) && crrAnim != animName)
		{
			animator.ResetTrigger(crrAnim);
		}

		crrAnim = animName;
		animator.SetTrigger(crrAnim);
	}
	public virtual void AddTarget(Character target)
	{
		targets.Add(target);
	}
	public virtual void RemoveTarget(Character target)
	{
		targets.Remove(target);
		//this.target = null;
	}
	public Character GetTargetInRange()
	{
        if (targets.Count > 0)
        {
			target = targets[Random.Range(0, targets.Count)];
        }
		return target;
    }
	public override void OnInit()
	{
		targetIndicator= LevelManager.Ins.CreateIndicatorPanel(indicatorPoint.transform);
	}
	public override void OnDespawn()
	{
	}
	public override void OnDeath()
	{
		targetIndicator.gameObject.SetActive(false);
		LevelManager.Ins.InitCharacterAlive();
		changeAnim("dead");
	}
	public override void OnAttack()
	{
	}
}
