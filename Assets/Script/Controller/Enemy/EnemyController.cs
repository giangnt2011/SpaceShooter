using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SpaceShipController
{
    protected override SpaceShipVO spaceShipVO => throw new System.NotImplementedException();

    public override void OnHit(float damage)
    {
        throw new System.NotImplementedException();
    }

    public override void OnSpaceShipDestroy()
    {
        throw new System.NotImplementedException();
    }

    public override void Shoot()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }
}
