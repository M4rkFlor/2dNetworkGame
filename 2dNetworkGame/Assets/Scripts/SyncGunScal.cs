using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

public class SyncGunScal : NetworkBehaviour
{


    [SyncVar]
    private Vector3 syncgunScale;
    [SerializeField]
    Transform mygunTransform;

    public override void OnStartLocalPlayer()
    {
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
            if (syncgunScale == Vector3.zero)
                print("GunsyncScalIsZero");
            else
                mygunTransform.localScale = syncgunScale;
        }
    }


    [Command]
    void CmdProvideScaleToSever(Vector3 Scale)
    {
        syncgunScale = Scale;
    }


    [ClientCallback]
    void TransmitScale()
    {
        if (isLocalPlayer)
        {
            if (mygunTransform.localScale == Vector3.zero)
                print("GunLocalScalIsZero");
            else
                CmdProvideScaleToSever(mygunTransform.localScale);
        }

    }





}