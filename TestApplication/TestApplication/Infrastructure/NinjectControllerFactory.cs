﻿using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Domain.Abstract;
using Domain.Concrete;

namespace TestApplication.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<IProductRepository>().To<ProductRepository>()
                .WithConstructorArgument("path", HttpContext.Current.Server.MapPath("~/JSONFiles/products.json"));
        }
    }
}