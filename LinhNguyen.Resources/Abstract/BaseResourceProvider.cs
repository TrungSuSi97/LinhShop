using LinhNguyen.Resources.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhNguyen.Resources.Abstract
{
    public abstract class BaseResourceProvider : IResourceProvider
    {
        // Cache list of resources
        private static Dictionary<string, ResourceEntry> _resources = null;
        private static object lockResources = new object();

        public BaseResourceProvider()
        {
            Cache = true; // By default, enable caching for performance
        }


        // Cache resources ?
        protected bool Cache { get; set; }

        /// <summary>
        /// Returns a single resource for a specific culture
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cultrue"></param>
        /// <returns></returns>
        public object GetResource(string name, string cultrue)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Resource name cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(cultrue))
            {
                throw new ArgumentException("Culture name cannot be null or empty.");
            }

            // nornalize
            cultrue = cultrue.ToLowerInvariant();

            if (Cache && _resources == null)
            {
                // Fetch all resources
                lock (lockResources)
                {
                    if (_resources == null)
                    {
                        _resources = ReadResources().ToDictionary(r => string.Format($"{r.Culture.ToLowerInvariant()}.{r.Name}"));
                    }
                }
            }

            if (Cache)
            {
                try
                {
                    return _resources[string.Format($"{cultrue}.{name}")].Value;
                }
                catch (Exception)
                {

                    throw null;
                }
            }

            return ReadResource(name, cultrue).Value;
        }

        /// <summary>
        /// Returns all resources for all cultures. (Needed for caching)
        /// </summary>
        /// <returns></returns>
        protected abstract IList<ResourceEntry> ReadResources();

        /// <summary>
        /// Returns a single resource for a specific culture
        /// </summary>
        /// <param name="name"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        protected abstract ResourceEntry ReadResource(string name, string culture);
    }
}
