using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpManager : BaseManager<TpManager>
{

    public int timer = 3;

    public bool isCanTp = true;

    

    public bool GetTpState()
    {
        return isCanTp;
    }
    public void StartTpTimer()
    {
        StartCoroutine(TpTimer(timer));
    }
    IEnumerator TpTimer(int timer)
    {
        while (true)
        {
            if (timer <= 0)
            {
                isCanTp = true;
                yield break;
            }
            else
            {
                isCanTp = false;
                yield return new WaitForSeconds(1.0f);
                timer--;
                
            }
        }
    }

   
}
