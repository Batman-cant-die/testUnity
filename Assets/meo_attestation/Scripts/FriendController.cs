using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendController : MonoBehaviour
{

    [SerializeField] private Transform mPlayer;
    [SerializeField] private float mFollowSpeed = 3f;
    [SerializeField] private float mAttackSpeed = 7f;
    [SerializeField] private float mAttackRadius = 10f;
    [SerializeField] CircleCollider2D mAttackTrigger;
    private Transform mTarget;
    private Vector3 mPlayerOffset;
    private bool mIsAttacking = false;
    private List<Transform> mEnemysOfRadius = new List<Transform>();

    void Start()
    {
        mPlayerOffset = transform.position - mPlayer.position;
        mTarget = mPlayer;
        mAttackTrigger.radius = mAttackRadius;
    }

    void Update()
    {
        float closesDistance = Mathf.Infinity;
        Transform closesEnemy = null;
        mTarget = mPlayer;
        mIsAttacking = false;

        foreach (var enemy in mEnemysOfRadius)
        {
            float distance = Vector3.Distance(transform.position, enemy.position);
            if(distance < closesDistance)
            {
                closesDistance = distance;
                closesEnemy = enemy;
            }

            if(closesEnemy != null)
            {
                mTarget = closesEnemy;
                mIsAttacking = true;
            }
            else
            {
                mTarget = mPlayer;
                mIsAttacking = false;
            }
        }

        MoveTotarget();
    }

    private void MoveTotarget()
    {
        var targetPos = mTarget.position + (mIsAttacking ? Vector3.zero : mPlayerOffset);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, mIsAttacking ? mAttackSpeed : mFollowSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
            mEnemysOfRadius.Add(collision.transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            mEnemysOfRadius.Remove(mTarget);
        else if (collision.tag == "Enemy")
            mEnemysOfRadius.Remove(collision.transform);
    }
}
