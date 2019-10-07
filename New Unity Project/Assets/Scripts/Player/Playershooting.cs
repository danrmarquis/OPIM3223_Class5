using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playershooting : MonoBehaviour
{
    public Projectile projectileprefab;
    public LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool mouseButtonDown = Input.GetMouseButtonDown(0);
        if (mouseButtonDown)
        {
            raycastOnMouseClick();

        }
        
    }
    void shoot (RaycastHit hit)
     {
        var projectile = Instantiate(projectileprefab).GetComponent<Projectile>();
        var PointAboveFloor = hit.point + new Vector3(0,this.transform.position.y, 0);
        var Direction = PointAboveFloor - transform.position;
        var shootRay = new Ray(this.transform.position, Direction);
        Physics.IgnoreCollision(GetComponent<Collider>(), projectile.GetComponent < Collider>());
        projectile.FireProjectile(shootRay);

 }
    void raycastOnMouseClick()
    {
        RaycastHit hit;
        Ray raytofloor = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(raytofloor, out hit, 100.0f, mask, QueryTriggerInteraction.Collide))
        {
            shoot(hit);
        }
    }
}

