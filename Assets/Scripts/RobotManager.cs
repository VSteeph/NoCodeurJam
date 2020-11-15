using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotManager : MonoBehaviour
{
    public List<MonsterManager> Monsters = new List<MonsterManager>();
    [SerializeField] private UnityEngine.Events.UnityEvent OnWin;
    void Start()
    {
        MonsterManager[] Mons = this.transform.GetComponentsInChildren<MonsterManager>();
        for(int i = 0; i < Mons.Length; i++)
        {
            Mons[i].robotManager = this;
            Monsters.Add(Mons[i]);
        }
    }

    void Update()
    {
        if(Monsters.Count == 0)
        {
            OnWin.Invoke();
        }
    }

    public void SyncEveryRobotPushBack(float force)
    {
        for (int i = 0; i < Monsters.Count; i++)
        {
            Monsters[i].pushBackOnHit += force;
        }
    }

    


}
