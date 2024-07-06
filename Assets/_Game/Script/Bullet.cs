using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //ban den dau
    [SerializeField] Transform target;
    //nguoi ban ra vien dan nay
    [SerializeField] Character character;
    private float speed = 20;
    [SerializeField] Transform child;
    CounterTime counterTime = new CounterTime();
	// Start is called before the first frame update
	void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
        child.Rotate(Vector3.up * -6, Space.Self);
        counterTime.Execute();
    }
    
    public void OnInit(Character character, Transform target)
    {
        this.character = character;
        this.target = target;
        transform.forward = (target.position - transform.position).normalized;
        counterTime.Start(deactiveBullet, 1f);
    }
	public void OnTriggerEnter(Collider other)
	{
        //Debug.Log("hit");
		if (other.CompareTag("Player") && other.gameObject != character.gameObject)
		{
            character.UpdatePoints();
			other.GetComponent<Character>().OnDeath();
            character.RemoveTarget(target.GetComponent<Character>());
            gameObject.SetActive(false);
        }
	}
	public void deactiveBullet()
    {
        gameObject.SetActive(false);
    }
}
