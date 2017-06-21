using UnityEngine;
using System.Collections;

public class titleCall : MonoBehaviour {

	Animator anim;
	bool isStart = false;

	void Start(){
		anim = GetComponent<Animator> ();
	}
		
	public void titleDestroy(){
		isStart = true;
		anim.SetBool ("isStart",true);
		
	} 

}
