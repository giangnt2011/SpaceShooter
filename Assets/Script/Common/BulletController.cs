using Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MovementController
{
    public float damage;
    int count = 0;

    private void Update()
    {
        Moving(transform.up);
        count++;
        if (count > 400)
        {
            Destroy(gameObject);
            Creator.Instance.CreateExplosion(transform);
        }
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, transform.up, 0.2f);
        //Debug.DrawRay(transform.position, transform.up, Color.red);

        if (hit.transform != null)
        {
            IHit ihit = hit.transform.GetComponent<IHit>();
            if (ihit != null)
            {
                ihit.OnHit(0);
                Creator.Instance.CreateExplosion(transform);
                Destroy(gameObject);
            }
        }
    }

}
