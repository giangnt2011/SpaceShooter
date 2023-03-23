using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateController : MonoBehaviour
{
    [SerializeField] private BulletController bulletPref;
    [SerializeField] private GameObject explosionPref;
    [SerializeField] private EnemyController enemyPref;
    [SerializeField] private WaveController wavePref;

    public BulletController CreateBulletPref(Transform tranShoot)
    {
        return Instantiate(bulletPref, tranShoot.position, tranShoot.rotation);
    }

    public void CreateExplosion(Transform pos)
    {
        Destroy(Instantiate(explosionPref, pos.position, pos.rotation), 0.5f);
    }
    public EnemyController CreateEnemy(Vector3 pos)
    {
        return Instantiate(enemyPref, pos, Quaternion.Euler(0, 0, 180));
    }

    public WaveController CreateWave(Vector3 pos)
    {
        return Instantiate(wavePref, pos, Quaternion.identity);
    }
    public GameObject LoadTilemap(GameObject tilemap)
    {
        return Instantiate(tilemap, Vector3.zero, Quaternion.identity);
    }
}
public class Creator : SingletonMonobehaviour<CreateController>
{

}
