using System;
using Demo.Scripts.FactoryMVPDemo;
using Demo.Scripts.VContainerDemo.LifetimeScopes;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.Helpers.VContainer
{
	public static class ContainerBuilderExtensions
	{
		public static void RegisterFromParent<TParent, TChild>(this IContainerBuilder builder,
			Func<TParent, TChild> selector, Lifetime lifetime) where TChild : class
		{
			builder.Register(resolver => selector(resolver.Resolve<TParent>()), lifetime);
		}

		/// <summary>
		/// Easier binding but more expensive since it is using reflection, can be benchmarked later on.
		/// </summary>
		public static void RegisterFromParent<TParent, TChild>(this IContainerBuilder builder, Lifetime lifetime)
			where TChild : class
		{
			builder.Register(resolver =>
			{
				var parent = resolver.Resolve<TParent>();
				var property = typeof(TParent).GetProperty(typeof(TChild).Name);
				return property?.GetValue(parent) as TChild;
			}, lifetime);
		}

		public static IContainerBuilder RegisterModelAndPresenter<TModel, TData, TPresenter, TView>(
			this IContainerBuilder builder,
			Lifetime lifetime = Lifetime.Transient)
			where TModel : BaseModel<TData>
			where TPresenter : BasePresenter<TModel, TView>
		{
			builder.Register<TModel>(lifetime);
			builder.Register<TPresenter>(lifetime);
			return builder;
		}


		public static void RegisterModelAndPresenter<TModel, TPresenter>(this IContainerBuilder builder,
			Lifetime lifetime)
			where TModel : class
			where TPresenter : class
		{
			builder.RegisterEntryPoint<TModel>(lifetime);
			builder.RegisterEntryPoint<TPresenter>(lifetime);
		}

		public static void RegisterMVP<TModel, TView, TPresenter>(this IContainerBuilder builder, TView viewInstance,
			Lifetime lifetime)
			where TModel : IBaseModel
			where TPresenter : IBasePresenter
			where TView : class
		{
			builder.RegisterEntryPoint<TModel>(lifetime);
			builder.RegisterEntryPoint<TPresenter>(lifetime);
			builder.RegisterComponent(viewInstance).AsImplementedInterfaces();
		}

		/// <summary>
		/// Makes it easier to bind a factory with a position, if more parameter are needed this can be expanded.
		/// </summary>
		public static void RegisterViewFactory<T>(this IContainerBuilder builder, GameObject prefab, Lifetime lifetime)
			where T : Component
		{
			builder.RegisterFactory<Vector3, T>(resolver =>
			{
				return position =>
				{
					var obj = resolver.Instantiate(prefab, position, Quaternion.identity);
					return obj.GetComponent<T>();
				};
			}, lifetime);
		}
		
		public static void RegisterMVPFactory<TModel, TData, TView, TPresenter>(this IContainerBuilder builder, Lifetime lifetime)
			where TModel : IFactoryModel<TData>, new()
			where TPresenter : IFactoryPresenter<TModel, TView>, new()
		{
			builder.RegisterFactory<TData, TModel>(resolver =>
			{
				return data =>
				{
					var model = new TModel();
					resolver.Inject(model);
					model.Initialize(data);
					return model;
				};
			}, lifetime);
    
			builder.RegisterFactory<TModel, TView, TPresenter>(resolver =>
			{
				return (model, view) =>
				{
					var presenter = new TPresenter();
					resolver.Inject(presenter);
					presenter.Initialize(model, view);
					return presenter;
				};
			}, lifetime);
		}
	}
}