using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{

    public float speed = 3f;
    public int rayRadius = 3;
    public float force = 5f;
    Vector3 hitPoint;
    bool move;
    Collider[] hitColliders;

    void Update()
    {
        if ( Input.GetMouseButtonDown(0) )
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if ( Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Road")) )
            {
                hitPoint = hit.point;
                hitPoint.y = 1;
                if ( !move )
                {
                    move = true;
                }
            }
        }

        hitColliders = Physics.OverlapSphere(transform.position, rayRadius, LayerMask.GetMask("Obstacle"));
        foreach ( Collider item in hitColliders )
        {
            Vector3 direction = item.transform.position - transform.position;
            if ( item.gameObject.GetComponent<Rigidbody>() == null )
            {
                item.gameObject.AddComponent<Rigidbody>();
                //Destroy(item.gameObject, 3f);
            }
            float distance = Vector3.Distance(transform.position, item.transform.position);
            item.GetComponent<Rigidbody>().AddForce((direction / distance) * force);
        }
    }

    private void FixedUpdate()
    {
        if ( move )
        {
            transform.position = Vector3.Lerp(transform.position, hitPoint, Time.fixedDeltaTime * speed);
        }
        
    }
}
