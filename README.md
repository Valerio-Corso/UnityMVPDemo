# UnityMVPDemo
A collection of simple demos to showcase the usage of an MVP pattern inside Unity and how these libraries can work together:
- IOC: VContainer
- Serialization: MemoryPack
- Reactive Programming: UniRx

Especially useful are the base classes and some extension methods to make binding easier, especially in regards to factories.

## FactoryViewDemo
Showcases the usage of factories to instantiate a view (gameobject)
## FactoryDemoMVP
Showcases the usage of factories to instantiate Model, View, Presenter, handling the model data and the disposal of objects.
## MessagePack
Showcases the usage of MessagePack together with VContainer and reactive properties, a simple file is dumped to the disk and read on startup.
## VContainer
Showcases the usage of an IoC container with an MVP pattern, uses multiple Lifecycles sharing the same data reference.
