using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour 
{
	public float speed ;
	// Use this for initialization
	void Start () 
	{
		speed = 5;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector2 position = transform.position;
		//compute the bullet's position
		position = new Vector2 (position.x, position.y + speed * Time.deltaTime);
		//update the bullet 's postion
		transform.position = position;
		// this is a top-right point of the screen
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		//if the bullet went outside the screen on the top then detroy the bullet
		if (transform.position.y > max.y)
		{
			Destroy(gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "EnemyShipTag") {
			Destroy(gameObject);
		}

	}
}
