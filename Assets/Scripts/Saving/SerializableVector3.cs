using UnityEngine;

[System.Serializable]
public class SerializableVector3
{
    public float x { get; set; }
    public float y { get; set; }
    public float z { get; set; }

    public SerializableVector3()
    {
        
    }
    
    public SerializableVector3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public Vector3 ToVector3()
    {
        return new Vector3(x, y, z);
    }
}
