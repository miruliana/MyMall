using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Resource;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace ShopServices.Windsor
{
	public static class WindsorService
	{
		private static bool isInstalled = false;
		private static object locker = new object();
		private static IWindsorContainer container = new WindsorContainer();
		private static IList<IWindsorInstaller> installers = new List<IWindsorInstaller>();

        public static IWindsorContainer Container
        {
            get
            {
                if (container == null)
                {
                    lock (locker)
                    {
                        if (container == null)
                        {
                            container = new WindsorContainer();
                        }
                    }
                }
                return container;
            }
        }
		 /// <summary>
        /// Adds installer to the container.
        /// </summary>
        /// <param name="installer"></param>
        public static void AddInstaller(IWindsorInstaller installer)
        {
            lock (locker)
            {
                if (!installers.Contains<IWindsorInstaller>(installer))
                {
                    installers.Add(installer);
                }
            }
        }

		 /// <summary>
        /// Adds installer to the container using embedded xml configuration file.
        /// </summary>
        /// <param name="assembly">Assembly containing the configuration file.</param>
        /// <param name="filename">The name of the configuration file;
        /// path must be included (e.g.: Configuration/Components.xml).</param>
        public static void AddAssemblyResourceInstaller(string assembly, string filename)
        {
           string assemblyResourcePath = String.Format("assembly://{0}/{1}", assembly, filename);
		  // AssemblyResource assemblyResource = new AssemblyResource(assemblyResourcePath);
		 
           IWindsorInstaller installer = Configuration.FromXml(new AssemblyResource(assemblyResourcePath));
           lock (locker)
            {
                if (!installers.Contains<IWindsorInstaller>(installer))
                {
                    installers.Add(installer);
                }
            }
        }

		  /// <summary>
        /// Installs container.
        /// </summary>
        public static void Install()
		{
            if (!isInstalled)
            {
                if (installers.Count > 0)
                {
                    container.Install(installers.ToArray());
                    isInstalled = true;
                }
                else
                {
                    throw new Exception(
                        "Can not install container: no installers have been added.");
                }
            }
            else
            {
                throw new Exception("Container is already installed! "
                    + "Clear() needs to be called before you can "
                    + "(re)install container.");
            }
        }

		/// <summary>
        /// Clears the container.
        /// </summary>
        public static void Clear()
        {
            container.Dispose();
            container = new WindsorContainer();
            isInstalled = false;
        }

		/// <summary>
        /// Resolves object from container.
        /// </summary>
        /// <typeparam name="T">Type of object to resolve.</typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }

        /// <summary>
        /// Resolves object with parameter from container.
        /// </summary>
        /// <typeparam name="T">Type of object to resolve.</typeparam>
        /// <returns></returns>
        public static T Resolve<T>(object argument)
        {
            return container.Resolve<T>(argument);
        }

		 /// <summary>
        /// Releases object fron container and frees up resources.
        /// </summary>
        /// <param name="instance"></param>
        public static void Release(object instance)
        {
            container.Release(instance);           
        }
		
	}
}
