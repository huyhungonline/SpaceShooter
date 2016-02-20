// design by Nguyen Huy Hung

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed =5;
	public  GameObject PlayerBullerGO; // this is player bullet prefab
	public GameObject BulletPosition01;
	public GameObject BulletPosition02;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () {
		// fire bullet when the spacebar is preed;
		if (Input.GetKeyDown ("space")) 
		{
			// intantiate 
			GameObject bullet01 = (GameObject)Instantiate (PlayerBullerGO);		
			bullet01.transform.position = BulletPosition01.transform.position;//set bullet initial positin
			GameObject bullet02 = (GameObject)Instantiate (PlayerBullerGO);
			bullet02.transform.position = BulletPosition02.transform.position;
		}
		float x = Input.GetAxisRaw ("Horizontal"); // the value will be -1, 0 , or i for(left , no input, and right)
		float y = Input.GetAxisRaw ("Vertical"); // the value will be -1,0 , or i ( for dow , no input , 
		Vector2 direction = new Vector2(x, y).normalized;

		Move (direction);
	}
	void Move( Vector2 direction)
	{
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));	
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		max.x = max.x - 0.225f;
		min.x = min.x + 0.225f;
		max.y = max.y - 0.285f;
		min.y = min.y + 0.285f;
		Vector2 pos = transform.position;
		pos += direction*speed*Time.deltaTime;	
		pos.x = Mathf.Clamp(pos.x,min.x,max.x);
		pos.y = Mathf.Clamp(pos.y,min.y,max.y);
		transform.position = pos;
	}
	void OnTriggerEnter2D(Collider2D col){
		if ((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag")) {
			Destroy(gameObject);
		}
	}
}
