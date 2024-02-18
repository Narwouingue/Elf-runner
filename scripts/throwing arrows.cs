using System.Collections;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject arrowPrefab;
    
    public Transform barrel;
    public float force;
    public float timeBetweenBullets;
    public int arrowLife;
    
    public GameObject bullet;

    private void Start()
    {
        StartCoroutine(wait());
    }


    private IEnumerator wait()

    {
        yield return new WaitForSeconds(3);
        StartCoroutine(FireRepeatedly());
    }
    private IEnumerator FireRepeatedly()
    {
        FireBullet();
        yield return new WaitForSeconds(timeBetweenBullets);
        StartCoroutine(FireRepeatedly());
    }

    private void FireBullet()
    {
        bullet = Instantiate(arrowPrefab, barrel.position, barrel.rotation);
        StartCoroutine(MoveArrow(bullet.transform, bullet.transform, force, arrowLife));
    }

    private IEnumerator MoveArrow(Transform arrowTransform, Transform arrowRotate, float speed, float lifetime)
    {
        float elapsedTime = 0f;
        

        {
            while (elapsedTime < lifetime)
            {
                arrowTransform.rotation = Quaternion.Euler(barrel.eulerAngles.x, barrel.eulerAngles.y / 2 , barrel.eulerAngles.z);
                    
                arrowTransform.Translate(arrowTransform.forward * speed * Time.deltaTime);
                arrowRotate.Rotate(barrel.eulerAngles.x, barrel.eulerAngles.y / 2, barrel.eulerAngles.z);
                yield return null;

                if (arrowTransform == null)
                {
                    yield break;
                }
            }

            Destroy(arrowTransform.gameObject);



        }
    }

    
}


