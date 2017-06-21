using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AudioController : MonoBehaviour {

	public AudioSource[] audioSource;
	public bool enterTheSkull = true;
	LordOfSkull lordOfSkull;
	GameController gameController;

	public AudioClip auClip00;
	public AudioClip auClip01;
	public AudioClip auClip02;
	public AudioClip auClip03;
	public AudioClip auClip04;

	//スペースキーの音を一回だけ鳴らすためのつかいすて変数
	public bool spacePushActive = true;

	void Start () {
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
		lordOfSkull = GameObject.Find ("LordOfSkull").GetComponent<LordOfSkull> ();
		audioSource = gameObject.GetComponents<AudioSource> ();
		audioSource[0].clip = auClip00;
		audioSource [0].Play();
	}

	void Update () {
		
		if (Input.GetButtonDown ("Jump") && spacePushActive == true) {
			PlayStartSound ();
			audioSource [0].Stop ();
			spacePushActive = false;
			StartCoroutine ("StartMainBGM");
		}
			
	}

	void PlayStartSound(){
		audioSource[1].clip = auClip01;
		audioSource [1].PlayOneShot(auClip01);
	}


	IEnumerator StartMainBGM (){
		yield return new WaitForSeconds (2.5f);
		audioSource [2].clip = auClip02;
		audioSource[2].Play ();
		enterTheSkull = false;
		//ロード・オブ・スカルのアニメーション再生
		//a値をいじる場合、spriteRendererには引数を渡さないとエラーが出る↓
		lordOfSkull.StartCoroutine("SpFadeIn",0.10f);

	}

}
