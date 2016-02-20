//design by nguyen huy hung
using UnityEngine;
using System.Collections;
// hinh ngoi sao
public class EnemyBullet : MonoBehaviour {
	float speed; // speed ò bullet
	Vector2 _direction;
	bool isReady;
	// Use this for initialization
	void Awake(){
		speed = 5f;
		isReady = false;
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	 	if (isReady) {
			//get bullet current position 
			Vector2 position = transform.position;
			// compute the bullet 's new position
			position += _direction*speed*Time.deltaTime;
			// updete buller 's positon
			transform.position = position;
			//this is a top-left
			Vector2 min = Camera.main.ViewportToWorldPoint( new Vector2(0,0));
			//this is a top-right
			Vector2 max =Camera.main.ViewportToWorldPoint( new Vector2(1,1));
			//  if bullet go outside then detroy bullet
			if((transform.position.x <min.x)||( transform.position.x> max.x)||(transform.position.y < min.y)||(transform.position.y > max.y))
			{
				Destroy(gameObject);
			}

			}

		}
	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "PlayerShipTag") {
			Destroy(gameObject);
		}
	}

	//funtion is set bullet direction 
	public void SetDirection( Vector2 direction)
	{
		// set direction normalize
		_direction = direction.normalized;
		isReady = true;	

	}
}
