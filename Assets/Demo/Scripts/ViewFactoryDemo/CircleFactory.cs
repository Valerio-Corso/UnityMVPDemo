using Core;
using Demo.Scripts.VContainerDemo.LifetimeScopes;
using UnityEngine;

namespace Demo.Scripts.ViewFactoryDemo
{
    public interface ICircleFactory
	{
		public CircleView Create(Transform parent, Vector3 position);
	}

	public class CircleFactory : BaseViewFactory<CircleView>, ICircleFactory
	{
        // In the case you want a model or presenter there is not really a great way to resolve dependenceis dynamically.
        // I think the best solution is pull here your dependencies and then in the Create method:
        // var view = Spawn(parent);
        // var model = new Model(data);
        // var presenter = new Presenter(view, model, otherDependencies...);
        // https://vcontainer.hadashikick.jp/registering/register-factory
        public CircleFactory()
		{
		}

        public CircleView Create(Transform parent, Vector3 position)
        {
            return SpawnView(position, parent);
        }
	}
}