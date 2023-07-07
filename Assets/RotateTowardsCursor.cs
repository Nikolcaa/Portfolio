using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsCursor : MonoBehaviour
{
    private void Update()
    {
        float dist = Vector2.Distance(transform.position, Cursor.Position);
        if (dist <= 2.5f)
        {
            Vector3 dir = Vector3.ClampMagnitude(transform.position - new Vector3(Cursor.Position.x, Cursor.Position.y, Cursor.Position.z - 0f), 1);
            //transform.forward = Vector3.Lerp(transform.forward, new Vector3(-dir.x, -dir.y, dir.z), Time.deltaTime * 6); // da ide u suprotni tilt prema cursoru
            transform.forward = Vector3.Lerp(transform.forward, new Vector3(dir.x, dir.y, dir.z), Time.deltaTime * 6);

        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 6);
        }
    }
}
