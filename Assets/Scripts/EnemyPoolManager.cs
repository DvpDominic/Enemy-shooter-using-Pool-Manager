using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolManager : MonoBehaviour {

    public static EnemyPoolManager Instance;
    public List<GameObject> UsedEnemy;
    //public List<GameObject> UnusedEnemy;
    public GameObject objectToPool;
    public int poolAmount = 5;
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public List<SpwanPos> spawanposes;

    // Use this for initialization
    void Awake () {
        Instance = this;
	}

    void Start()
    {
        UsedEnemy = new List<GameObject>();
        for(int i=0; i < poolAmount; i++)
        {
            GameObject enemy = (GameObject) Instantiate (objectToPool);
            enemy.transform.position = spawanposes[i].Pos.position;
            spawanposes[i].PosStatus = true;
            enemy.GetComponent<EnemyController>().PosId = i;
            UsedEnemy.Add(enemy);
            enemy.SetActive(true);
           
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < UsedEnemy.Count; i++)
        {
            if (!UsedEnemy[i].activeInHierarchy)
            {
                return UsedEnemy[i];
            }
        }   
        return null;
    }

    public void OnKill(GameObject enemy)
    {
        Debug.Log("Kill");
        enemy = Instance.GetPooledObject();
        enemy.transform.position = spawanposes[enemy.GetComponent<EnemyController>().PosId].Pos.position;
        enemy.SetActive(true);

    }


}
[System.Serializable]
public class SpwanPos
{
    public Transform Pos;
    public bool PosStatus;
}