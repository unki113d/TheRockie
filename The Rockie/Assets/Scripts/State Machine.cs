using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
}
/*   #FIX
 * class StateMachine 
{
    public Dictionary<Type, AState> States = new Dictionary<Type, AState>();
}
abstract class AState
{
    public abstract void Enter();
    public abstract void Exit();
}
class GreenState : AState
{
    public override void Enter()
    {
        Debug.Log("Enter green");
    }
    public override void Exit()
    {
        Debug.Log("Enter green");
    }
}
*/