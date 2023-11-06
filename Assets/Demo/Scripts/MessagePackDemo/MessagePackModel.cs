using System.Collections.Generic;
using System.IO;
using Core;
using Demo.Scripts.VContainerDemo;
using MessagePack;
using UnityEngine;
using Random = System.Random;

namespace Demo.Scripts.MessagePackDemo
{
    public interface IMessagePackModel
    {
        public void CreateRandomList();
        void Serialize();
    }
    public class MessagePackModel : BaseModel<IMessagePackData>, IMessagePackModel
    {
        private const string MessagepackDataBin = "messagepack_data.bin";
        private readonly string _projectRoot;
        private readonly Random _random;

        public MessagePackModel(HelloWorldService helloWorldService)
        {
            _random = new Random();
            _projectRoot = Directory.GetParent(Application.dataPath).FullName;
            Deserialize();
        }

        public void CreateRandomList()
        {
            var randomNumber = _random.Next(5);
            Data.RandomNumber = randomNumber;

            Data.Child = new();
            Data.Child.RandomList = new List<string>(randomNumber);

            for (int i = 0; i <= randomNumber; i++)
            {
                Data.Child.RandomList.Add("entry " + i);
            }
        }

        public void Serialize()
        {
            var serialized = MessagePackSerializer.Serialize(Data);
            var json = MessagePackSerializer.ConvertToJson(serialized);
            Debug.Log(json);
            
            // Write the serialized MessagePack binary data to a file in the project root
            File.WriteAllBytes(Path.Combine(_projectRoot, MessagepackDataBin), serialized);

            // Write the JSON representation to a file in the project root
            File.WriteAllText(Path.Combine(_projectRoot, "messagepack_data.json"), json);
        }
        
        private void Deserialize()
        {
            string filePath = Path.Combine(_projectRoot, MessagepackDataBin);

            // Check if the file exists before trying to deserialize
            if (File.Exists(filePath))
            {
                byte[] serializedData = File.ReadAllBytes(filePath);
                var data = MessagePackSerializer.Deserialize<IMessagePackData>(serializedData);
                Debug.Log("Save found, Deserialized object:");
                Debug.Log(data.ToString());
            }
            else
            {
                Debug.Log("Save not found, data has never been serialized");
            }
        }
    }
}