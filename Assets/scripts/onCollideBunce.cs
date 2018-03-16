using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollideBunce : MonoBehaviour {

	private void OnCollisionEnter2D(Collision2D other) {
		ContactPoint2D contact = other.contacts[0];
		Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
		rb.AddForce(contact.normal * contact.relativeVelocity.magnitude * 0.6f, ForceMode2D.Impulse);
	}
}
