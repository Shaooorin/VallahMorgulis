using UnityEngine;
using System.Collections;

public class PressSpace : MonoBehaviour {

	Animator anim;
	bool isPressSpace = false;

	void Start(){
		anim = GetComponent<Animator> ();

	}

	public void SpaceDestroy(){
		isPressSpace = true;
		anim.SetBool ("isPressSpace",true);

	} 
}
