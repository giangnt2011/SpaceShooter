using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : SpaceShipController
{
    protected override SpaceShipVO spaceShipVO => DataController.Instance.playerVO;

    protected override void Awake()
    {
        base.Awake();
        levelController.SetLevel(1);
    }

    protected override void Update()
    {
        base.Update();
        if(Input.GetMouseButton(0))
        {
            Vector3 castPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector3.Lerp(transform.position, new Vector3(castPoint.x, transform.position.y), 0.03f);
        }
    }

    public override void OnSpaceShipDestroy()
    {
        
    }

    public override void Shoot()
    {
        foreach(Transform tranShoot in tranShoots)
        {
            BulletController bullet = Creator.Instance.CreateBulletPref(tranShoot);
            bullet.speed = spaceShipInfo.speed * 1.5f;
        }
    }

    public override void OnHit(float damage)
    {
        
    }
}

public class Player : SingletonMonobehaviour<SpaceShipController>
{

}
