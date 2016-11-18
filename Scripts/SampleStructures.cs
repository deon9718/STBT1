using UnityEngine;

public class SampleStructures : Unit
{
    public Color LeadingColor;
    public override void Initialize()
    {
        base.Initialize();
        transform.position += new Vector3(0, 0, -1);
        GetComponentInChildren<Renderer>().material.color = LeadingColor;
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
    }

    public override void MarkAsFriendly()
    {
        //GetComponent<Renderer>().material.color = LeadingColor + new Color(1, 1, 1);
    }

    public override void MarkAsReachableEnemy()
    {
        //GetComponent<Renderer>().material.color = LeadingColor + Color.red ;
    }

    public override void MarkAsSelected()
    {
        //GetComponent<Renderer>().material.color = LeadingColor + Color.green;
    }

    public override void UnMark()
    {
        //GetComponent<Renderer>().material.color = LeadingColor;
    }
}
