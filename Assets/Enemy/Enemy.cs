using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject enemyPrefab;
    [Header("Posicion")]
    public float minXPosition;
    public float maxXPosition;
    [Header("Tiempo")]
    public float minTimeToCreate;
    public float maxTimeToCreate;

    public float timeToCreateEnemy;
    public float currenTimeToCreate;

    public GameManagerControl gameManager;

    // Start is called before the first frame update
    void Start()
    {
        timeToCreateEnemy = Random.Range(minTimeToCreate, maxTimeToCreate);
    }

    // Update is called once per frame
    void Update()
    {
        currenTimeToCreate = currenTimeToCreate + Time.deltaTime;
        
        if (currenTimeToCreate >= timeToCreateEnemy)
        {
            Vector2 positionToCreate = new Vector2(Random.Range(minXPosition, maxXPosition), 6.7f);
            GameObject enemy = Instantiate(enemyPrefab, positionToCreate, transform.rotation);
            enemy.GetComponent<ControlEnemy>().SetGameManager(gameManager);
            timeToCreateEnemy = Random.Range(minTimeToCreate, maxTimeToCreate);
            currenTimeToCreate = 0;
        }
    }
}
