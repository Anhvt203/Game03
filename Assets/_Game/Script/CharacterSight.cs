using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSight : MonoBehaviour
{
	[SerializeField] Character character;
	private void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("Player"))
        {
			character.AddTarget(other.gameObject.GetComponent<Character>());
        }
    }
	private void OnTriggerExit(Collider other)
	{
		character.RemoveTarget(other.gameObject.GetComponent<Character>());
	}
}
