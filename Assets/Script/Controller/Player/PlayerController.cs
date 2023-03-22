using DesignPattern;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : SpaceShipController
{
    protected override SpaceShipVO spaceShipVO => DataController.Instance.playerVO;
    public Vector3 playerTransformPos;

    protected override void Awake()
    {
        base.Awake();
        levelController.SetLevel(1);
        Observer.Instance.AddObserver(GameKey.ENEMY_DIE, OnEnemyDie);
        
    }

    protected override void Update()
    {
        playerTransformPos = transform.position;


        base.Update();

        if (Input.GetMouseButton(0))
        {
            Vector3 castPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 newPosition = Vector3.Lerp(transform.position, new Vector3(castPoint.x, transform.position.y), 0.03f);
            newPosition.x = Mathf.Clamp(newPosition.x, -GetScreenWidthToWorldPoint() / 2 + 0.5f, GetScreenWidthToWorldPoint() / 2 - 0.5f);
            transform.position = newPosition;
        }


    }

    public override void OnSpaceShipDestroy()
    {
        Debug.Log("You Lose");
        Invoke("DestroyGameObject", 1f);
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
    public override void Shoot()
    {
        foreach(Transform tranShoot in tranShoots)
        {
            BulletController bullet = Creator.Instance.CreateBulletPref(tranShoot);
            bullet.speed = spaceShipInfo.speed * 1.5f;
            bullet.damage = spaceShipInfo.damage;
        }
    }

    public override void OnHit(float damage)
    {
        TakeDamage(damage);
    }

    protected override void Moving(Vector3 postion)
    {
        throw new NotImplementedException();
    }
    void OnEnemyDie(object data)
    {
        EnemyController enemy = (EnemyController)data;
        levelController.UpdateEXP(enemy.levelEnemy * 20);
        Debug.Log("66 "+ enemy.levelEnemy);
    }
}

public class Player : SingletonMonobehaviour<PlayerController>
{

}
