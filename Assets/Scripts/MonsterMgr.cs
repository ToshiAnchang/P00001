using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMgr : MonoBehaviour
{

    [SerializeField] Transform[] spawnTrs;
    [SerializeField] Monster mob;
    public int WorldMonsterCount;

    private static MonsterMgr instance;
    public static MonsterMgr Instance
    {
        get { return instance; }
    }

    List<Monster> aliveMonsterList = new List<Monster>();


    private void Awake()
    {
        instance = this;
    }


    public int countSpawn;
    public int spawnSec;
    public bool spawning;

    
    // Start is called before the first frame update
    void Start()
    {
        spawning = true;
        WorldMonsterCount = 0;
        StartCoroutine(SpawnCoroutine());
    }


    IEnumerator SpawnCoroutine()
    {
        for(int i = 0; i < countSpawn; i++)
        {            
            yield return new WaitForSeconds(spawnSec);
            for(int k = 0; k < spawnTrs.Length; k++)
            {
                Monster _mob = Instantiate(mob);                                
                _mob.Spawn(spawnTrs[k].position);
                //WorldMonsterCount += 1;
                aliveMonsterList.Add(_mob);
            }            
        }
        spawning = false;
    }

    public void DestroyMonster(Monster monster)
    {
        //WorldMonsterCount--;
        //if (aliveMonsterList.Count <= 0) { return; }
        if (!aliveMonsterList.Contains(monster))        {            return;        }
        aliveMonsterList.Remove(monster);
        if (!spawning && aliveMonsterList.Count <= 0)
        {
            print("Ŭ���� ���� �����Ͽ����ϴ�.");
        }
        //if(spawning == false)


/*        if(spawning != true && WorldMonsterCount <= 0) {
            print("Ŭ���� ���� �޼�");
        }*/
 /*       if (WorldMonsterCount < 3)
        {
            countSpawn -= WorldMonsterCount;            
            print("countSpawn="+countSpawn+" // ������ ���� ���ڴ� "+WorldMonsterCount+" ���� �Դϴ�.");
        }
        if (WorldMonsterCount >= 3)
        {            
            print("���Ͱ� �� �� �ֽ��ϴ�~~~");
        }*/
    }

    public Monster FindClosest(Vector2 _pos)
    {
        if(aliveMonsterList.Count <= 0) { return null; }

        float distance2 = float.MaxValue;
        int k = 0;
        
        for(int i = 0; i < aliveMonsterList.Count; i++)
        {
            float distance = Vector2.Distance(_pos, aliveMonsterList[i].transform.position);
            if(distance < distance2)
            {
                distance2 = distance;
                k = i;
            }
        }
        return aliveMonsterList[k];
    }



}
