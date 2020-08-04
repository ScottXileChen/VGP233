using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
    private bool mIsFirstUpdata = true;

    void Update()
    {
        if(mIsFirstUpdata)
        {
            mIsFirstUpdata = false;
            Loader.LoaderCallBack();
        }
    }
}
