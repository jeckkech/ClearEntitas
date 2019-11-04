using Entitas;
using UnityEngine;
using Entitas.Unity;

public class EmitInputSystem : IInitializeSystem, IExecuteSystem
{
    readonly InputContext _context;
    readonly IGroup<InputEntity> _inputs;

    private InputEntity _leftMouseButtonEntity;


    public EmitInputSystem(Contexts contexts) {        
        _context = contexts.input;
        _inputs = _context.GetGroup(InputMatcher.AnyOf(InputMatcher.LeftMouse, InputMatcher.MouseDown, InputMatcher.MouseUp, InputMatcher.MousePosition));
    }

    public void Execute()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Collider2D raycastHit2D = ColliderHit(Input.mousePosition);

        GameEntity _currentTarget = null;

        if (_leftMouseButtonEntity.hasCurrentTarget && _leftMouseButtonEntity.currentTarget.entityRef != null) {
            _currentTarget = _leftMouseButtonEntity.currentTarget.entityRef;            
        }

        if (raycastHit2D != null)
        {
            GameEntity entity = raycastHit2D.gameObject.GetEntityLink().entity as GameEntity;
            if (_leftMouseButtonEntity.hasCurrentTarget)
            {
                _leftMouseButtonEntity.ReplaceCurrentTarget(entity);
            }
            else {
                _leftMouseButtonEntity.AddCurrentTarget(entity);
            }
        }
        else {
            _leftMouseButtonEntity.ReplaceCurrentTarget(_currentTarget);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (raycastHit2D != null)
            {
                _leftMouseButtonEntity.ReplaceCurrentTarget(_currentTarget);
                _leftMouseButtonEntity.ReplaceMouseDown(mousePosition);              

                if (_currentTarget != null)
                {
                    _currentTarget.ReplacePosition(mousePosition);
                }
            }
            else {
                _leftMouseButtonEntity.RemoveCurrentTarget();
                _currentTarget = null;
            }
        }
        if (Input.GetMouseButton(0))
        {
            _leftMouseButtonEntity.ReplaceCurrentTarget(_currentTarget);
            _leftMouseButtonEntity.ReplaceMousePosition(mousePosition);
                    
            if (_currentTarget != null)
            {
                _currentTarget.ReplacePosition(mousePosition);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            _leftMouseButtonEntity.RemoveCurrentTarget();
            _leftMouseButtonEntity.ReplaceMouseUp(mousePosition);            
            _currentTarget = null;
        }
 
    }

    public void Initialize()
    {
        _context.isLeftMouse = true;
        _leftMouseButtonEntity = _context.leftMouseEntity;       
    }

    private Collider2D ColliderHit(Vector2 mousePosition) {
        return Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePosition), Vector2.zero, 100).collider;
    }

}
