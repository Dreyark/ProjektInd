﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollision : MonoBehaviour
{
    CarMovement m_Movement;

    private void Awake()
    {
        m_Movement = GetComponent<CarMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.collider.name + " " + collision.collider.tag);
        if( collision.collider.CompareTag("Obstacle") == true)
        {
            m_Movement.OnCollideWithObstacle();
        }
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if( otherCollider.CompareTag("Oil") == true)
        {
            m_Movement.OnEnterOil();
        }

        if (otherCollider.CompareTag("OffCourseArea") == true)
        {
            m_Movement.OnEnterOffCourseArea();
        }
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("OffCourseArea") == true)
        {
            m_Movement.OnExitOffCourseArea();
        }

        if (otherCollider.CompareTag("Oil") == true)
        {
            m_Movement.OnExitOffOil();
        }
    }
}
