using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	titleCall titleCaller;
	PressSpace spacePusher;
	FadeController fadeController;
	AudioController audioController;
	LordOfSkull lordOfSkull;

	GameObject introText01;
	GameObject introText02;
	GameObject questionA;
	GameObject questionB;
	GameObject questionC;
	GameObject outroNormal;
	GameObject outroBad;
	GameObject no;
	GameObject yes;
	GameObject choiceHint;
	GameObject finalAnswer;

	bool intro01off = true;
	bool intro02on = true;
	bool intro02off = true;

	bool quest01on = true;
	bool quest01off = true;
	bool quest01choiceOn = true;
	bool quest01choiceOff = true;

	bool quest02on = true;
	bool quest02off = true;
	bool quest02choiceOn = true;
	bool quest02choiceOff = true;

	bool quest03on = true;
	bool quest03off = true;
	bool quest03choiceOn= true;
	bool quest03choiceOff = true;

	bool quest04on = true;

	bool normalEndon = true;
	bool normalEndoff = true;
	bool badEndon = true;
	bool badEndoff = true;

	void Start () {
		titleCaller = GameObject.Find ("Title").GetComponent<titleCall>();
		spacePusher = GameObject.Find ("enterSpace").GetComponent<PressSpace> ();
		fadeController = GameObject.Find ("Canvas").GetComponent<FadeController> ();
		audioController = GameObject.Find ("AudioController").GetComponent<AudioController> ();
		introText01 = GameObject.Find ("introText01");
		introText01.SetActive (false);
		introText02 = GameObject.Find ("introText02");
		introText02.SetActive (false);
		questionA = GameObject.Find ("questA");
		questionA.SetActive (false);
		questionB = GameObject.Find ("questB");
		questionB.SetActive (false);
		questionC = GameObject.Find ("questC");
		questionC.SetActive (false);
		outroNormal = GameObject.Find ("outroText_NORMAL");
		outroNormal.SetActive (false);
		outroBad = GameObject.Find ("outroText_BAD");
		outroBad.SetActive (false);
		no = GameObject.Find ("NO");
		no.SetActive (false);
		yes = GameObject.Find ("YES");
		yes.SetActive (false);
		choiceHint = GameObject.Find ("choiceHint");
		choiceHint.SetActive (false);
		finalAnswer = GameObject.Find ("finalAnswer");
		finalAnswer.SetActive (false);
	}

	//----------------------------------------------------------------------------------------

	//ゲームフロー中のコルーチンを使用した遅延処理のまとめ

	//intro01を表示させるコルーチン
	IEnumerator FirstIntroOn (){
		yield return new WaitForSeconds(4.5f);
		Debug.Log ("いんとろ１");
		fadeController.StartCoroutine ("CanvasFadeIn");
		introText01.SetActive (true);
	}

	//intro01を消すコルーチン
	IEnumerator FirstIntroOff(){
		yield return new WaitForSeconds (14);
		fadeController.StartCoroutine ("CanvasFadeOut");
		intro02on = false;
		Debug.Log ("いんとろ１きえる");
	}

	//intro02を表示させるコルーチン
	IEnumerator SecondIntroOn(){
		yield return new WaitForSeconds (1.5f);
		Debug.Log ("いんとろ２");
		introText01.SetActive (false);
		introText02.SetActive (true);
		fadeController.StartCoroutine ("CanvasFadeIn");
		intro02off = false;
	}

	//intro02を消すコルーチン
	IEnumerator SecondIntroOff(){
		yield return new WaitForSeconds (10f);
		Debug.Log ("いんとろ２きえる");
		fadeController.StartCoroutine ("CanvasFadeOut");
		quest01on = false;
	}

	//quest01を表示させるコルーチン
	IEnumerator FirstQuestOn(){
		yield return new WaitForSeconds (3f);
		Debug.Log ("くえすとA");
		introText02.SetActive (false);
		questionA.SetActive (true);
		fadeController.StartCoroutine ("CanvasFadeIn");
		quest01off = false;
	}

	//quest01を消すコルーチン
	IEnumerator FirstQuestionOff(){
		yield return new WaitForSeconds (10);
		Debug.Log ("くえすとAきえる");
		fadeController.StartCoroutine ("CanvasFadeOut");
		quest01choiceOn = false;
	}

	//quest01の選択肢を表示するコルーチン
	IEnumerator FirstDecisionOn(){
		yield return new WaitForSeconds (2);
		Debug.Log ("くえすとAせんたくし");
		questionA.SetActive (false);
		choiceHint.SetActive (true);
		no.SetActive (true);
		yes.SetActive (true);
		fadeController.StartCoroutine ("CanvasFadeIn");
		quest01choiceOff = false;
	}

	//quest02を表示させるコルーチン
	IEnumerator SecondQuestionOn(){
		yield return new WaitForSeconds (2);
		questionA.SetActive (false);
		questionB.SetActive (true);
		fadeController.StartCoroutine ("CanvasFadeIn");
		quest02off = false;
	}

	//quest02を消すコルーチン
	IEnumerator SecondQuestionOff(){
		yield return new WaitForSeconds (12);
		fadeController.StartCoroutine ("CanvasFadeOut");
		quest02choiceOn = false;
	}

	//quest02の選択肢を表示するコルーチン
	IEnumerator SecondDecisionOn(){
		yield return new WaitForSeconds (2);
		questionB.SetActive (false);
		choiceHint.SetActive (true);
		no.SetActive (true);
		yes.SetActive (true);
		fadeController.StartCoroutine ("CanvasFadeIn");
		quest02choiceOff = false;
	}

	//quest03を表示させるコルーチン
	IEnumerator ThirdQuestionOn(){
		yield return new WaitForSeconds (3);
		questionA.SetActive (false);
		questionB.SetActive (false);
		questionC.SetActive (true);
		fadeController.StartCoroutine ("CanvasFadeIn");
		quest03off = false;
	}

	//quest03を消すコルーチン
	IEnumerator ThirdQuestionOff(){
		yield return new WaitForSeconds (12);
		fadeController.StartCoroutine ("CanvasFadeOut");
		quest03choiceOn = false;
	}

	//quest03の選択肢を表示するコルーチン
	IEnumerator ThirdDecisionOn(){
		yield return new WaitForSeconds (2);
		questionC.SetActive (false);
		choiceHint.SetActive (true);
		no.SetActive (true);
		yes.SetActive (true);
		fadeController.StartCoroutine ("CanvasFadeIn");
		quest03choiceOff = false;
	}

	//ノーマルエンドを表示するコルーチン
	IEnumerator NormalEndOn(){
		yield return new WaitForSeconds (2);
		outroNormal.SetActive (true);
		fadeController.StartCoroutine ("CanvasFadeIn");
	}

	//ノーマルエンドを消して、シーンをリセット
	IEnumerator NormalEndOff(){
		yield return new WaitForSeconds (17);
		fadeController.StartCoroutine ("CanvasFadeOut");
		StartCoroutine ("BackToSquareOne");
	}

	//バッドエンドを表示するコルーチン
	IEnumerator BadEndOn(){
		yield return new WaitForSeconds (2);
		outroBad.SetActive (true);
		fadeController.StartCoroutine ("CanvasFadeIn");
	}

	//バッドエンドを消してシーンをリセット
	IEnumerator BadEndOff(){
		yield return new WaitForSeconds (17);
		fadeController.StartCoroutine ("CanvasFadeOut");
		StartCoroutine ("BackToSquareOne");
	}


	//待機時間を挟んで、ゲームシーンの一番最初まで戻る
	IEnumerator BackToSquareOne(){
		yield return new WaitForSeconds (2);
		Debug.Log ("おしまい");
		SceneManager.LoadScene ("ep01");
	}

	//---------------------------------------------------------------------------------------

	void Update () {

		//コルーチンでどんどん表示・非表示を回していく
		//bool型変数の真偽で処理が回っていく 
		//他の処理によって値が初期化されることはないため問題なく回る
		intro01off = true;

		if (Input.GetButtonDown ("Jump") && audioController.spacePushActive == true) {
			titleCaller.titleDestroy ();
			spacePusher.SpaceDestroy ();
			intro01off = false;
			StartCoroutine ("FirstIntroOn");
		}
			
		if(intro01off == false){
			StartCoroutine ("FirstIntroOff");
		}

		if (intro02on == false) {
			StartCoroutine ("SecondIntroOn");
			intro02on = true;
		}

		if(intro02off == false){
			StartCoroutine ("SecondIntroOff");
			intro02off = true;
		}

		if(quest01on == false){
			StartCoroutine ("FirstQuestOn");
			quest01on = true;
		}

		if(quest01off == false){
			StartCoroutine("FirstQuestionOff");
			quest01off = true;
		}

		if(quest01choiceOn == false){
			StartCoroutine("FirstDecisionOn");
			quest01choiceOn = true;
		}

		//質問への答えによって分岐させる-----------------------------------------------------------------------
		//quest01choiceOffは選択肢が表示されるときにfalseになる

		//質問が表示された状態で、矢印キーの「↑」が押されたら　(yesが選択された状態)
		if(Input.GetKeyDown(KeyCode.UpArrow) && quest01choiceOff == false){
			yes.SetActive (true);
			no.SetActive (false);
			audioController.audioSource [4].PlayOneShot(audioController.auClip04);
			choiceHint.SetActive (false);
			finalAnswer.SetActive (true);
			normalEndon = false;
			quest02on = true;
		}

		//質問が表示された状態で、矢印キーの「↓」が押されたら　(noが選択された状態)
		if(Input.GetKeyDown(KeyCode.DownArrow) && quest01choiceOff == false){
			yes.SetActive (false);
			no.SetActive (true);
			audioController.audioSource [4].PlayOneShot(audioController.auClip04);
			choiceHint.SetActive (false);
			finalAnswer.SetActive (true);
			normalEndon = true;
			quest02on = false;
		}

		//quest01でyesでもnoでも、とにかく何らかの選択肢を確定した場合
		if (Input.GetButtonDown ("Jump") && choiceHint.activeSelf == false && quest01choiceOff == false) {
			audioController.audioSource [3].PlayOneShot(audioController.auClip03);
			questionB.SetActive (false);
			choiceHint.SetActive (false);
			yes.SetActive (false);
			no.SetActive (false);
			finalAnswer.SetActive (false);
			quest01choiceOff = true;
		}

		//quest01でyesの選択を確定させた場合、normalEndへ
		if(Input.GetButtonDown("Jump") && normalEndon == false && quest02on == true){
			normalEndon = true;
			quest01off = true;
			Debug.Log ("ノーマルエンド");
			StartCoroutine ("NormalEndOn");
			StartCoroutine ("NormalEndOff");
		}

		//quest02を表示させる
		if(Input.GetButtonDown("Jump") && normalEndon == true && quest02on == false){
			quest02on = true;
			Debug.Log ("くえすとB");
			StartCoroutine ("SecondQuestionOn");
		}

		//------------------------------------------------------------------------------------------------

		if(quest02off == false){
			Debug.Log ("くえすとBきえる");
			quest02off = true;
			StartCoroutine ("SecondQuestionOff");
		}

		if(quest02choiceOn == false){
			quest02choiceOn = true;
			Debug.Log ("くえすとBせんたくし");
			StartCoroutine ("SecondDecisionOn");
		}

		//---------------------最初の選択肢と同じ処理------------------------------------

		//質問が表示された状態で、矢印キーの「↑」が押されたら　(yesが選択された状態)
		if(Input.GetKeyDown(KeyCode.UpArrow) && quest02choiceOff == false){
			yes.SetActive (true);
			no.SetActive (false);
			audioController.audioSource [4].PlayOneShot(audioController.auClip04);
			choiceHint.SetActive (false);
			finalAnswer.SetActive (true);
			normalEndon = false;
			quest03on = true;
			Debug.Log ("2度目の↑");
		}

		//質問が表示された状態で、矢印キーの「↓」が押されたら　(noが選択された状態)
		if(Input.GetKeyDown(KeyCode.DownArrow) && quest02choiceOff == false){
			yes.SetActive (false);
			no.SetActive (true);
			audioController.audioSource [4].PlayOneShot(audioController.auClip04);
			choiceHint.SetActive (false);
			finalAnswer.SetActive (true);
			normalEndon = true;
			quest03on = false;
			Debug.Log ("2度目の↓");
		}

		//yesでもnoでも、とにかく何らかの選択肢を確定させた場合
		if (Input.GetButtonDown ("Jump") && choiceHint.activeSelf == false && quest02choiceOff == false) {
			audioController.audioSource [3].PlayOneShot(audioController.auClip03);
			yes.SetActive (false);
			no.SetActive (false);
			finalAnswer.SetActive (false);
			quest02off = true;
			Debug.Log ("せんたくしけってい２");
		}

//		Debug.Log ("quest01choiceoff : " + quest01choiceOff);

		//quest02でyesの選択を確定させた場合、normalEndへ
//		if(Input.GetButtonDown("Jump") && normalEndon == false && quest03on == true){
//			quest02choiceOff = true;
//			normalEndon = true;
//			Debug.Log ("ノーマルエンド2");
////			StartCoroutine ("NormalEndOn");
////			StartCoroutine ("NormalEndOff");
//		}

		if(Input.GetButtonDown("Jump") && quest03on == false){
			quest02choiceOff = true;
			quest03on = true;
			Debug.Log ("くえすとC");
			StartCoroutine("ThirdQuestionOn");
		}

		//---------------------三番目(最後の)の返答の処理------------------------------------

		if(quest03off == false){
			quest03off = true;
			Debug.Log ("くえすとCきえる");
			StartCoroutine ("ThirdQuestionOff");
		}

		if(quest03choiceOn == false){
			quest03choiceOn = true;
			Debug.Log ("くえすとCせんたくし");
			StartCoroutine ("ThirdDecisionOn");
		}

		//質問が表示された状態で、矢印キーの「↑」が押されたら　(yesが選択された状態)
		if(Input.GetKeyDown(KeyCode.UpArrow) && quest03choiceOff == false){
			yes.SetActive (true);
			no.SetActive (false);
			audioController.audioSource [4].PlayOneShot(audioController.auClip04);
			choiceHint.SetActive (false);
			finalAnswer.SetActive (true);
			normalEndon = false;
			badEndon = true;
			quest04on = true;
			Debug.Log ("3度目の↑");
		}

		//質問が表示された状態で、矢印キーの「↓」が押されたら　(noが選択された状態)
		if(Input.GetKeyDown(KeyCode.DownArrow) && quest03choiceOff == false){
			yes.SetActive (false);
			no.SetActive (true);
			audioController.audioSource [4].PlayOneShot(audioController.auClip04);
			choiceHint.SetActive (false);
			finalAnswer.SetActive (true);
			normalEndon = true;
			badEndon = false;
			quest04on = false;
			Debug.Log ("3度目の↓");
		}

		//yesでもnoでも、とにかく何らかの選択肢を確定させた場合
		if (Input.GetButtonDown ("Jump") && choiceHint.activeSelf == false && quest03choiceOff == false) {
			audioController.audioSource [3].PlayOneShot(audioController.auClip03);
			yes.SetActive (false);
			no.SetActive (false);
			finalAnswer.SetActive (false);
			quest03choiceOff = true;
			Debug.Log ("せんたくしけってい3");
		}

//		if(Input.GetButtonDown ("Jump") && choiceHint.activeSelf == false && quest04on == false){
//			quest04on = true;
//			Debug.Log ("ノーマルエンド３");
//		}

		if(Input.GetButtonDown ("Jump") && choiceHint.activeSelf == false && badEndon == false){
			badEndon = true;
			Debug.Log ("バッドエンド");
			StartCoroutine ("BadEndOn");
			StartCoroutine ("BadEndOff");
		}


	}

}
