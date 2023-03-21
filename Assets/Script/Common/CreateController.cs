using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateController : MonoBehaviour
{
    [SerializeField] private BulletController bulletPref;
    [SerializeField] private GameObject explosionPref;

    public BulletController CreateBulletPref(Transform tranShoot)
    {
        return Instantiate(bulletPref, tranShoot.position, Quaternion.identity);
    }

    public void CreateExplosion(Transform pos)
    {
        Destroy(Instantiate(explosionPref, pos.position, pos.rotation), 0.5f);
    }
}
public class Creator : SingletonMonobehaviour<CreateController>
{

}
