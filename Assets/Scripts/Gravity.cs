using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attire tout objet ayant une Rigidbody vers celui-ci.
/// La GameObject doit avoir une SphereCollider avec isTrigger = true.
/// La GameObject doit avoir une GameObject avec un autre SphereCollider.
/// Pour élargir la région gravitationnelle, changer le rayon de la SphereCollider [isTrigger = true]
/// Denis Labrecque, Décembre 2018
/// Attribution 4.0 International
/// </summary>
[RequireComponent(typeof(SphereCollider))]
public class Gravity : MonoBehaviour
{
    const float G = 667.4f;
    public float gravityFactor = 2f;

	public static List<Gravity> Attractors;

	public Rigidbody rb;

	void FixedUpdate ()
	{
		foreach (Gravity attractor in Attractors)
		{
			if (attractor != this)
				Attract(attractor);
		}
	}

	void OnEnable ()
	{
		if (Attractors == null)
			Attractors = new List<Gravity>();

		Attractors.Add(this);
	}

	void OnDisable ()
	{
		Attractors.Remove(this);
	}

	void Attract (Gravity objToAttract)
	{
		Rigidbody rbToAttract = objToAttract.rb;

		Vector3 direction = rb.position - rbToAttract.position;
		float distance = direction.magnitude;

		if (distance <= 100f)
			return;

		float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
		Vector3 force = direction.normalized * forceMagnitude;

		rbToAttract.AddForce(force);
	}
}