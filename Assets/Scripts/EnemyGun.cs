//design by nguyen huy hung
using UnityEngine;
using System.Collections;
// class control bullet
public class EnemyGun : MonoBehaviour {
	public GameObject EnemyBulletGO; // this is our enemy bullet prefab
	// Use this for initialization
	void Start () {
	// fire an enemy bullet after 1 second
		Invoke ("FireEnemyBullet", 1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	// funtin fire enemy bullet
	void FireEnemyBullet()
	{
		//  get reference to the player's ship
		GameObject playerShip = GameObject.Find ("PlayerGO");
		if (playerShip != null) {
			//instantiate an enemy bullet
			GameObject bullet = (GameObject)Instantiate(EnemyBulletGO);
			//set the bullet's position
			bullet.transform.position=transform.position;
			// compute the bullet position forward the player
			Vector2 direction = playerShip.transform.position- bullet.transform.position;
			//set the bullet direction
			bullet.GetComponent<EnemyBullet>().SetDirection(direction);
		}

	}
}
