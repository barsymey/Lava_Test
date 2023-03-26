using UnityEngine;

public interface IPickableResource
{
    /// <summary> Directly assign GameObject that resource will be picked by when time comes. Also prevents from being picked by other pickers. </summary>
    public void AssignPicker(GameObject picker);

    /// <summary> Try to assign picker that resource will be picked by. Only successfull if time passed or no picker assigned previously. </summary>
    void Pick(GameObject picker);
}
