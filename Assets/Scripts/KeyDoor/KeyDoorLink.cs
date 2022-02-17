public class KeyDoorLink
{
    public KeyDoorLink(string id, BaseDoor door, BaseKey key)
    {
        ID = id;
        Door = door;
        Key = key;
    }

    public string ID { get; private set; }
    public BaseDoor Door { get; private set; }
    public BaseKey Key { get; set; }
}