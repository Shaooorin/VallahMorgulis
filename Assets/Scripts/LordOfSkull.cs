using UnityEngine;
using System.Collections;

public class LordOfSkull : MonoBehaviour {

	SpriteRenderer spRend;
	float alphaColor;

	void Start () {
		spRend = gameObject.GetComponent<SpriteRenderer> ();
		spRend.color = new Color (1, 1, 1, alphaColor);
	}

	//ロード・オブ・スカル　登場時のフェードイン
	//透明度の値に0.1をかけて初期化 同じことを0.1秒毎に10回繰り返す
	public IEnumerator SpFadeIn(float alpha){
		for (int n = 0; n < 10; n++) {
			alphaColor = n * 0.1f;
			spRend.color = new Color (1, 1, 1, alphaColor);
			yield return new WaitForSeconds (0.1f);
		}
	}

//	public IEnumerator SpFadeOut(float alpha){
//		for (int n = 9; n >= 0; n --){
//			alphaColor = n * 0.1f;
//			spRend.color = new Color (1,1,1,alphaColor);
//			yield return new WaitForSeconds (0.1f);
//		}
//	}


}