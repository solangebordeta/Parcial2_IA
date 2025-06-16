using UnityEngine;

//Asegura que cualquier clase de comportamiento de steering implemente el m�todo MoveDirection().
public interface ISteering 
{
    //Devuleve un Vector3 con la direcci�n del movimiento deseado.
    public Vector3 MoveDirection();
}
