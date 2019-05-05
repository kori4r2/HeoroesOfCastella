using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ConnectionManager : NetworkBehaviour
{
    public GameObject canvasObject;
    // Start is called before the first frame update
    void Start()
    {
        if(isLocalPlayer){
            GameObject obj = InstantiateCanvas();
            foreach(Transform t in obj.transform){
                t.position += new Vector3(Random.Range(10f, 50f), 0, 0);
            }
        }
    }

    [Client]
    GameObject InstantiateCanvas(){
        Debug.Log("rodou");
        return Instantiate(canvasObject);
    }
    
    [TargetRpc]
    public void TargetDestroyCanvas(NetworkConnection conn){
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("LocalPlayer")){
            Destroy(go);
        }
    }
}
