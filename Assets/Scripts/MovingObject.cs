﻿using UnityEngine;
using System.Collections;

public abstract class MovingObject : MonoBehaviour {

    public float moveTime = 0.1f;  //Time it will take object to move, in seconds.
    public LayerMask blockingLayer;  //Layer on which collision will be checked.


    private BoxCollider2D boxCollider;    //The BoxCollider2D component attached to this object.
    private Rigidbody2D rb2D;            //The Rigidbody2D component attached to this object.
    private float inverseMoveTime;      //Used to make movement more efficient.



    // Use this for initialization
    protected virtual void start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
        inverseMoveTime = 1f / moveTime;

	}

    protected bool Move (int xDir, int yDir, out RaycastHit2D hit)
    {
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(xDir, xDir);

        boxCollider.enabled = false;
        hit = Physics2D.Linecast(start, end, blockingLayer);
        boxCollider.enabled = true;

        if(hit.transform == null)
        {
            StartCoroutine(SmoothMovement(end));
            return true;
        }
    }
    protected IEnumerator SmoothMovement (Vector2 end)
    {
        float sqrRemainingDistance = (transform.position (end)).sqrMagnitude;

        while (sqrRemainingDistance > float.Epsilon)
        {
            Vector2 newPosition = Vector2.MoveTowards(rb2D.position, end, inverseMoveTime * Time.deltaTime);
            rb2D.MovePosition(newPosition);
            sqrRemainingDistance = (transform.position (end)).sqrMagnitude;
            yield return null;
        }
    }
    protected virtual void AttemptMove <T> (int xDir, int yDir)
        where T : Component
    {
        RaycastHit2D hit;
        bool canMove = Move(xDir, yDir, out hit);
        if (hit.transform == null)
            return;

        T hitComponent = hit.transform.GetComponent<T>();

        if (!canMove && hitComponent != null)
            OnCantMove(hitComponent);

    }

    protected abstract void OnCantMove<T>(T component)
     where T : Component;
}
