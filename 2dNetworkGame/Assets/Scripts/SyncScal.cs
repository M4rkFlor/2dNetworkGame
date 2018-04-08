using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

public class SyncScal : NetworkBehaviour
{

    
   [SyncVar]
    private Vector3 syncScale;
    [SerializeField] Transform myTransform;

	public override void OnStartLocalPlayer() {
		//myTransform = this.transform;
        //transform.localScale = scale;
    }

    void FixedUpdate()
    {

        TransmitScale();
        ReciveScale();

    }
    void ReciveScale()
    {
        if (!isLocalPlayer)
        {
            if (syncScale == Vector3.zero)
               print("syncScalIsZero");
            else
                myTransform.localScale = syncScale;
        }
    }


    [Command]
    void CmdProvideScaleToSever(Vector3 Scale)
    {
        syncScale = Scale;
    }


    [ClientCallback]
    void TransmitScale()
    {
        if (isLocalPlayer)
        {
            if (myTransform.localScale == Vector3.zero)
                print("LocalScalIsZero");
            else
            CmdProvideScaleToSever(myTransform.localScale);
        }
           
    }




    
}