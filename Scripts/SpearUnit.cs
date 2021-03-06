﻿using UnityEngine;
using System.Collections;

public class SpearUnit : Unit
{
    public Color LeadingColor;
    public SpriteRenderer highlight;
    public Object spear;
    public GameObject bloodParticles;

    public override void Initialize()
    {
        base.Initialize();
        transform.position += new Vector3(0, 0, -1);
        highlight = transform.FindChild("Man_Highlight").GetComponent<SpriteRenderer>();
        highlight.enabled = false;
        //GetComponentInChildren<Renderer>().material.color = LeadingColor;
    }

    protected virtual IEnumerator throwSpear(GameObject projectile, Vector3 targetPos, float speed)
    {
        Vector3 dispersion = new Vector3(Random.Range(-0.25f, 0.25f), Random.Range(-0.25f, 0.25f));
        targetPos += dispersion;
        while (projectile.transform.position != targetPos)
        {
            projectile.transform.position = Vector3.MoveTowards(projectile.transform.position, targetPos, Time.deltaTime * speed);
            yield return 0;
        }
    }

    public override void MarkAsAttacking(Unit other)
    {
        Vector3 dir = other.transform.position - transform.position;
        dir.Normalize();
        float angleVariance = Random.Range(-10, 10);
        GameObject projectile = (GameObject)Instantiate(spear, transform.position, Quaternion.identity);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90 + angleVariance;
        projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        StartCoroutine(throwSpear(projectile, other.transform.position, 50));

    }

    public override void MarkAsDefending(Unit other)
    {
    }

    public override void MarkAsDestroyed()
    {
        GameObject bloodEffect = (GameObject)Instantiate(bloodParticles, transform.position, Quaternion.identity);
    }

    public override void MarkAsFinished()
    {
        highlight.color = new Color(0, 0, 0, 0.5f);
        highlight.enabled = true;
    }

    public override void MarkAsFriendly()
    {
        highlight.color = new Color(0, 1, 0, 0.5f);
        highlight.enabled = true;
    }

    public override void MarkAsReachableEnemy()
    {
        highlight.color = new Color(0, 0, 1, 0.5f);
        highlight.enabled = true;
    }

    public override void MarkAsSelected()
    {
        highlight.color = new Color(1, 1, 0, 0.5f);
        highlight.enabled = true;
    }

    public override void UnMark()
    {
        highlight.enabled = false;
    }
}
