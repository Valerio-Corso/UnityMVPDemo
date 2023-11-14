using System.Collections.Generic;
using MessagePack;
using UniRx;

namespace Demo.Scripts.MessagePackDemo
{
    /// <summary>
    /// Union is for interfaces, so that the serializer knows how to resolve the concrete type.
    /// If this is used by multiple classes they can be listed with another key
    /// [Union(1, typeof(AnotherClass))]
    /// </summary>
    [Union(0, typeof(MessagePackData))]
    public interface IMessagePackData
    {
        int RandomNumber { get; set; }
        ReactiveProperty<int> RxRandomNumber { get; set; }
        MessagePackDataChild Child { get; set; }
    }

    /// <summary>
    /// [Key(0)] just means the object will be serialized with this identifier instead of a string, main benefit: much more performant.
    /// Entries can be serialized as string instead, see example below MessagePackData. [MessagePackObject(true)]
    /// </summary>
    [MessagePackObject]
    public class MessagePackDataChild
    {
        [Key(0)] 
        public List<string> RandomList { get; set; }

        public override string ToString()
        {
            return $"RandomList: [{string.Join(", ", RandomList)}";
        }
    }
    
    /// <summary>
    /// For demonstration purpose we have a reference to another class MessagePackDataChild instead of the RandomList, demonstrating nested MessagePackObject.
    /// </summary>
    [MessagePackObject(true)]
    public class MessagePackData : IMessagePackData
    {
        public int RandomNumber { get; set; }
        public ReactiveProperty<int> RxRandomNumber { get; set; }
        public MessagePackDataChild Child { get; set; }

        public override string ToString()
        {
            return $"RandomNumber: {RandomNumber}, {Child.ToString()}]";
        }

        public MessagePackData() 
        {
            RxRandomNumber = new ReactiveProperty<int>(150);
        }
    }
}