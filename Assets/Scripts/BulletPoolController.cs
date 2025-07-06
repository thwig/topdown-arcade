using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int poolSize;
    private Queue<GameObject> bulletPool = new Queue<GameObject>();
    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }

    public GameObject GetBullet(Vector2 pos, Quaternion rotation)
    {
        GameObject bullet = bulletPool.Dequeue();
        bullet.transform.position = pos;
        bullet.transform.rotation = rotation;
        bullet.SetActive(true);
        bulletPool.Enqueue(bullet);
        return bullet;
    }
}
