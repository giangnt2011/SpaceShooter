using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base;
using Common;
using System;

[System.Serializable]

public class SpaceShipInfo
{
    public float speed;
    public float MaxHP;
    public float MaxEXP;
    public float damage;
}

public abstract class SpaceShipController : MonoBehaviour,IHit
{
    [SerializeField] protected SpaceShipInfo spaceShipInfo;
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
        hpController.InitValue(spaceShipInfo.MaxHP);
        levelController.InitMaxEXP(spaceShipInfo.MaxEXP);
    }

    public abstract void OnHit(float damage);

    protected float MovingXaxis()
    {
        return Mathf.Clamp(transform.position.x, -GetScreenWidthToWorldPoint() / 2 + 0.5f, GetScreenWidthToWorldPoint() / 2 - 0.5f);
    }

    protected abstract void Moving(Vector3 postion);

    protected float GetScreenWidthToWorldPoint()
    {
        float screenWidth = Screen.width;
        Camera mainCamera = Camera.main;
        float worldWidth = mainCamera.ScreenToWorldPoint(new Vector3(screenWidth, 0, 0)).x - mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;

        return worldWidth;
    }
}
