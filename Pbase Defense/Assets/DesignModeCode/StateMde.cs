using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMde : MonoBehaviour {
    void Start()
    {
        Context context = new Context();
        context.SetState(new ConcreteStateA(context));
        context.Handle(5);
        context.Handle(10);
        context.Handle(30);
        context.Handle(20);
        context.Handle(5);
        context.Handle(3);
    }
}

public class Context {
    private IState _state;

    public void SetState(IState state)
    {
        this._state = state;
    }

    public void Handle(int arg)
    {
        this._state.Handle(arg);
    }
}

public interface IState
{
    void Handle(int arg);
}

public class ConcreteStateA : IState
{
    private Context _context;

    public ConcreteStateA(Context context)
    {
        this._context = context;
    }

    public void Handle(int arg)
    {
        Debug.Log("ConcreteStateA: arg=" + arg);
        if (arg > 20)
        {
            _context.SetState(new ConcreteStateB(_context));
        }
    }
}

public class ConcreteStateB : IState
{
    private Context _context;

    public ConcreteStateB(Context context)
    {
        this._context = context;
    }

    public void Handle(int arg)
    {
        Debug.Log("ConcreteStateB: arg=" + arg);

        if (arg < 10)
        {
            _context.SetState(new ConcreteStateA(_context));
        }
    }
}


