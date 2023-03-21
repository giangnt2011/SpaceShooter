using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base;
using Common;

[System.Serializable]

public class SpaceShipInfo
{
    public float speed;
    public float MaxHP;
    public float MaxEXP;
    public float damage;
}

public abstract class SpaceShipController : MovementController,IHit
{
    protected SpaceShipInfo[] spaceShipInfos;
    protected SpaceShipInfo spaceShipInfo;
    [SerializeField] protected Transform[] tranShoots;
    [SerializeField] protected HPController hpController;
    [SerializeField] protected LevelController levelController;
    int countToShoot = 0;
    Vector3 startPosition;

    protected abstract SpaceShipVO spaceShipVO { get; }

    protected virtual void Awake()
    {
        hpController.die = OnSpaceShipDestroy;
        levelController.onUpLevel = OnUpLevel;
        startPosition = transform.position;
    }

    protected virtual void Update()
    {
        countToShoot ++;
        if(countToShoot > 300)
        {
            Shoot();
            countToShoot = 0;
        }
        
    }
    public abstract void Shoot();
    public abstract void OnSpaceShipDestroy();

    public void TakeDamage(float damage)
    {
        hpController.TakeDamge(damage);
    }

    public void OnUpLevel(int level)
    {
        spaceShipInfo = spaceShipVO.GetSpaceShipInfo(level);
        speed = spaceShipInfo.speed;
        hpController.InitValue(spaceShipInfo.MaxHP);
        levelController.InitMaxEXP(spaceShipInfo.MaxEXP);
    }

    public abstract void OnHit(float damage);

    protected void MoveOnScreen(Vector3 pos)
    {
        Vector3 distance = pos - startPosition;

        //var offSet = bgImageSizeX / 3;
        //var disPos = Vector3.Distance(pos, startPosition);
        //if (disPos > offSet)
        //{
        //    var newPos = startPosition + offSet * distance.normalized;
        //    innerCircle.transform.position = newPos;
        //}
        //else
        //{
        //    innerCircle.transform.position = eventData.position;
        //}
    }
}
