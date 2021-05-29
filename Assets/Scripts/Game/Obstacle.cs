using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IComparable<Obstacle> {

	public SpriteRenderer MySpriteRenderer{ get; set;}

	private Color defaultColor;
	private Color fadedtColor;



	void Start(){

		MySpriteRenderer = GetComponent<SpriteRenderer> ();
		defaultColor = MySpriteRenderer.color;
		fadedtColor = defaultColor;
		fadedtColor.a = 0.6f;
	}

	#region IComparable implementation
	public int CompareTo (Obstacle other)
	{
		if (MySpriteRenderer.sortingOrder > other.MySpriteRenderer.sortingOrder) {
			return 1;
		}else if (MySpriteRenderer.sortingOrder < other.MySpriteRenderer.sortingOrder) {
			return -1;
		}
		return 0;
	}
	#endregion


	public void FadeOut(){
		MySpriteRenderer.color = fadedtColor;
	}

	public void FadeIn(){
		MySpriteRenderer.color = defaultColor;
	}


}
