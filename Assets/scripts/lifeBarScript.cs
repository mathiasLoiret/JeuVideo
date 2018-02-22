using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeBarScript : MonoBehaviour {

    public float hp;
    public float maxHp;
    private float lifePercent;

    public Transform foreground;
    public Transform background;

    private float xScale = 5;
    public float yScale = 0.5f;
    private float borderScale = 0.1f;

    // Use this for initialization
    void Start () {
        updateHP(hp);
        updateLifeBar();
    }
	
	// Update is called once per frame
	void Update () {
    }

    void updateLifeBar()
    {
        lifePercent = hp / maxHp;
        foreground.localScale = new Vector3(lifePercent * xScale, yScale, foreground.localScale.z);
        background.localScale = new Vector3(xScale + 2 * borderScale, yScale + borderScale, background.localScale.z);
        background.position = new Vector3(foreground.position.x - borderScale, background.position.y, background.position.z);
    }

    internal void addLP(float v)
    {
        updateHP(hp + v);
        updateLifeBar();
    }

    internal void resetLifeBar(float hp, float maxHp)
    {
        this.maxHp = maxHp;
        updateHP(hp);
        updateLifeBar();
    }

    void updateHP(float newHpValue)
    {
        if (newHpValue > maxHp)
            hp = maxHp;
        else if (newHpValue < 0)
            hp = 0;
        else
            hp = newHpValue;
    }
}
