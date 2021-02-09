using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    [Header("Cup Heights:")]
    public float minHeight = 2.04f;
    public float maxHeight = 2.75f;

    public float moveSpeed = 3f;

    public GameObject coin;

    public Vector3 targetPosition;

    public Vector3 cupStart;
    public Vector3 coinStart;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
        cupStart = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (coin != null)
        {
            coin.transform.position = new Vector3(transform.position.x, coin.transform.position.y, transform.position.z);
        }
    }

    public void MoveUp()
    {
        targetPosition = new Vector3(transform.position.x, maxHeight, transform.position.z);
    }

    public void MoveDown()
    {
        targetPosition = new Vector3(transform.position.x, minHeight, transform.position.z);
    }
}
