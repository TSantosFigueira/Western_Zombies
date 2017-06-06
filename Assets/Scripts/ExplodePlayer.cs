using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodePlayer : MonoBehaviour {

    public List<GameObject> enemyParts = new List<GameObject>();

    public GameObject blood;
    int dx;
    int dy;
    int rz;

    public void Explosion()
    {
        for (int x = 0; x < 200; x++)
        {
            dx = Random.Range(-3000, 3000);
            dy = Random.Range(-500, 3000);
            rz = Random.Range(-5000, 5000);
            GameObject bloodInst = Instantiate(blood, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.Euler(0, 0, 0));
            bloodInst.GetComponent<Rigidbody>().AddForce(new Vector2(dx, dy), ForceMode.Force);
        }

        for (int i = 0; i < enemyParts.Count; i++)
        {
            dx = Random.Range(-3000, 3000);
            dy = Random.Range(-500, 3000);
            rz = Random.Range(-5000, 5000);
            GameObject parts = Instantiate(enemyParts[i], new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.Euler(0, 0, 0));
            parts.GetComponent<Rigidbody>().AddForce(new Vector2(dx, dy), ForceMode.Force);
            parts.GetComponent<Rigidbody>().AddTorque(new Vector3(0, 0, rz));
        }
    }

}
