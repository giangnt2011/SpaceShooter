using DesignPattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SpaceShipController
{
    protected override SpaceShipVO spaceShipVO => DataController.Instance.enemyVO;

    public int levelEnemy;
    protected override void Awake()
    {
        base.Awake();

    }
    private void Start()
    {
        levelController.SetLevel(levelEnemy);
    }
    protected override void Update()
    {
        base.Update();
        if (Player.Instance != null)
        {
                Vector3 newPosition = Vector3.Lerp(transform.position, Player.Instance.transform.position,spaceShipInfo.speed * Time.deltaTime * 0.01f);
                newPosition.x = Mathf.Clamp(newPosition.x, -GetScreenWidthToWorldPoint() / 2 + 0.5f, GetScreenWidthToWorldPoint() / 2 - 0.5f);
                transform.position = newPosition;
        }
    }

    public override void OnHit(float damage)
    {
        TakeDamage(damage);
    }

    public override void OnSpaceShipDestroy()
    {
        Observer.Instance.Notify(GameKey.ENEMY_DIE, this);
        Destroy(gameObject);
    }

    public override void Shoot()
    {
        foreach( Transform t in tranShoots)
        {
            BulletController bullet = Creator.Instance.CreateBulletPref(t);
            bullet.speed = spaceShipInfo.speed;
            bullet.damage = spaceShipInfo.damage;
        }
    }


    protected override void Moving(Vector3 position)
    {
        
    }
}
