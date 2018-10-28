﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyMoveLevel : MonoBehaviour
{
    float MoveSpeed = 20.0f;
    private float accumTimeAterUpdate;
    private float updateTime;
    private Vector3 myposition;
    private ThreadStart td;
    private Thread t;
    private int count = 0;
    private int turnCount = 50;
    public int maxTurnCount;
    Vector3 lookDirection;

    public GameObject target;
    // Use this for initialization
    void Start()
    {
        myposition = transform.position;
        target = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(target.transform);
    }

    // Update is called once per frame
    void Update()
    {
        accumTimeAterUpdate += Time.deltaTime;
        count++;

        if(count % turnCount == 0 && count / turnCount <= maxTurnCount)
        {
            target = GameObject.FindGameObjectWithTag("Player");
            transform.LookAt(target.transform);
        }

        if (accumTimeAterUpdate >= updateTime)
        {
            accumTimeAterUpdate = 0;
            this.transform.Translate(Vector3.forward * Time.deltaTime * MoveSpeed);
        }
        if (gameObject.transform.position.x < -30 || gameObject.transform.position.x > 30 || gameObject.transform.position.z < -36 || gameObject.transform.position.x > 33)
        {
            Destroy(gameObject);
        }
    }
}