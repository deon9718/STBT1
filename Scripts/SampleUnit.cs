using UnityEngine;

public class SampleUnit : Unit
{
    public Color LeadingColor;
    public SpriteRenderer highlight;

    public override void Initialize()
    {
        base.Initialize();
        transform.position += new Vector3(0, 0, -1);
        highlight = transform.FindChild("Man_Highlight").GetComponent<SpriteRenderer>();
        highlight.enabled = false;
        //GetComponentInChildren<Renderer>().material.color = LeadingColor;
    }
    public override void MarkAsAttacking(Unit other)
    {      
    }

    public override void MarkAsDefending(Unit other)
    {       
    }

    public override void MarkAsDestroyed()
    {      
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
