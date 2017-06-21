using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FadeController : MonoBehaviour {

	public CanvasGroup canvas;


	void Start () {
		canvas = gameObject.GetComponent<CanvasGroup> ();
	}

//	キャンパス全体の透明度を制御するためのクラス

	//繰り返しを一回ずつ計算すれば何故こういう式になるかわかります
	//繰り返しの値を代入して、継続条件がfalseになるまで計算してみましょう
	//理解しずらいのはCanvasFadeOutのほうです
	//フェードアウトは数が大きい状態から小さくなっていくので
	//初期化式は9(不透明度90%)もしくは10(不透明度100%)からでなければなりません

	//　for(初期化式; 継続条件式; 変化式)

	//キャンバスグループをフェードアウト
	public IEnumerator CanvasFadeOut(){
		for (int n = 9; n >= 0; n --) {
			//アルファ(透明度)を0.1ずつ初期化　10回繰り返す
			canvas.alpha = n * 0.1f;
			yield return new WaitForSeconds (0.1f);
			//繰り返すたびに待機時間を挟む
			//これがないと、繰り返し処理が一瞬で終了してしまいフェードにならない
		}
	}

	//キャンバスグループをフェードイン
	public IEnumerator CanvasFadeIn(){
		for(int n = 0; n <= 10; n ++){
			//アルファ(透明度)を0.1ずつ初期化　10回繰り返す
			canvas.alpha = n / 10.0f;
			yield return new WaitForSeconds (0.1f);
			//繰り返すたびに待機時間を挟む
			//これがないと、繰り返し処理が一瞬で終了してしまいフェードにならない
		}

	}


}
