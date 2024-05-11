using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
	/// Robert Longenbach
	/// This script is for bullets to be spawned and modified
	/// 5-5-24
   enum SpawnerType { Straight, Spin }
   [Header("Bullet Attributes")]
   public GameObject bullet;
   public float bulletLife = 1f;
   public float speed = 1f;

   [Header("Spawner Attributes")]
   [SerializeField] private SpawnerType spawnerType;
   [SerializeField] private float firingRate = 1f;

   private GameObject spawnedBullet;
   private float timer = 0f;

   void Update()
   {
	timer += Time.deltaTime;
	if(spawnerType == SpawnerType.Spin) transform.eulerAngles = new Vector3(0f,0f,transform.eulerAngles.z+1f);
	if(timer >= firingRate) {
		Fire();
		timer = 0;
	}
   }
	// add a enumerator to add a delay to the bullets
   private void Fire() {
	if (bullet) {
		spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
		spawnedBullet.GetComponent<Bullet>().speed = speed;
		spawnedBullet.GetComponent<Bullet>().bulletLife = bulletLife;
		spawnedBullet.transform.rotation = transform.rotation;
	}
   } 


}
