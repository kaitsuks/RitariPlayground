using UnityEngine;
using System.Collections;
using System;

public abstract class PGAction : MonoBehaviour
{
	public virtual bool ExecuteAction(GameObject other)
	{
		//the return value indicates if the action has been successful
		//some actions always return true
		return true;
	}

    internal void Invoke()
    {
        throw new NotImplementedException();
    }
}
