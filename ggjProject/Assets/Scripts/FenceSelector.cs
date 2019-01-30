using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(GameController))]
public class FenceSelector : MonoBehaviour{

    public GameObject[] fencesN, fencesS, fencesE, fencesW;
    private List<GameObject> fencesDown = new List<GameObject>();

    public GameController gc;
    public float fallingInterval = 4f;
    private float counter = 0f;
    private float maxSimultaneous = 2f;
    private int fencesDownAmnt = 0;
    
    
    void Restart() {

        gc = GetComponent<GameController>();
        fallingInterval = 4f * gc.levelMultiplier;
        counter = 0f;
        maxSimultaneous = 2.2f * gc.levelMultiplier;
        fencesDownAmnt = 0;
        RestartFences(fencesN);        
        RestartFences(fencesS);        
        RestartFences(fencesE);        
        RestartFences(fencesW);

        //tirando referencia de todas as cercas listadas como desativadas
        fencesDown.Clear();
    }

    void RestartFences( GameObject[] fences) {

        foreach (GameObject f in fences)
            f.SetActive(true);
    }

    //sorteia se ira cair uma cerca ou nao
    public bool WillFall(int chance) {

        return UnityEngine.Random.Range(0, chance) != 0;
    }

    //funcao que player ira executar ao restaurar uma cerca.
    public void ReplaceFence(GameObject f) {
        if(fencesDown.Contains(f)){
            f.SetActive(true);
            fencesDown.Remove(f);
        }
    }

    public void PutDownFence() {
        if(fencesDownAmnt < maxSimultaneous && counter > fallingInterval) {
            //vamos entao sortear se caira uma ou nao
            if (WillFall(gc.currLevel + (int)(gc.levelTime / 35f))) {
                SelectFence(UnityEngine.Random.Range(1, 5));
                counter = 0f;
                fencesDownAmnt++;
                fallingInterval *= 1f - gc.currLevel/150f;
                maxSimultaneous *= 0.4f + gc.currLevel/100;
            }
            else  //garante que esperara mais um tempo antes de voltar a tentar
                counter /= 2;
            
        }
    }

    private void SelectFence(int position) {

        GameObject f = null;
        switch (position) {
            case 1:     //norte
                f = fencesN[UnityEngine.Random.Range(0, fencesN.Length - 1)];
                break;
            case 2:     //sul
                f = fencesS[UnityEngine.Random.Range(0, fencesS.Length - 1)];
                break;
            case 3:     //leste
                f = fencesE[UnityEngine.Random.Range(0, fencesE.Length - 1)];
                break;
            case 4:     //oeste
                f = fencesW[UnityEngine.Random.Range(0, fencesW.Length - 1)];
                break;
        }
        Debug.Log($"Removing fence at {f.transform.position}. Position {position}. {fencesDownAmnt}/{maxSimultaneous}");
        f.SetActive(false);
        fencesDown.Add(f);

    }

    private void Update() {

        counter += Time.deltaTime;
        gc.levelTime += Time.deltaTime;
        maxSimultaneous += (gc.currLevel * gc.levelTime + gc.levelTime/100)/6000;

        PutDownFence();

    }


}
