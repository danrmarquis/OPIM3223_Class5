using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public GameObject Target;

    private Transform enemyTransform;
    // Start is called before the first frame update
    void Start()
    {
        enemyTransform = this.transform.parent;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Target == null)
        {
            return;
        }
        enemyTransform.position = Vector3.Lerp(enemyTransform.position, Target.transform.position, Time.deltaTime * speed);
    }
}
