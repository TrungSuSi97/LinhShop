using LinhNguyen.Resources.Abstract;
using LinhNguyen.Resources.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LinhNguyen.Resources.Utility
{
    public class ResourceBuilder
    {
        /// <summary>
        /// Generates a class with properties for each resource key
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="namespaceName"></param>
        /// <param name="className"></param>
        /// <param name="filePath"></param>
        /// <param name="summaryCulture"></param>
        /// <returns></returns>
        public virtual string Create(BaseResourceProvider provider, string namespaceName = nameof(Resources), string className = nameof(Resources),
             string filePath = null, string summaryCulture = null)
        {
            //Retrieve all resources
            MethodInfo method = provider.GetType().GetMethod("ReadResources", BindingFlags.Instance | BindingFlags.NonPublic);

            IList<ResourceEntry> resources = method.Invoke(provider, null) as List<ResourceEntry>;

            if (resources==null || resources.Count == 0)
            {
                throw new Exception(string.Format($"No resources were found in {provider.GetType().Name}"));
            }

            // Get a unique list of resource names (keys)
            var keys = resources.Select(r => r.Name).Distinct();

            #region Templates 
            const string header =
                @"using System;
                using System.Collections.Generic;
                using System.Globalization;
                using System.Linq
                using System.Text;
                using System.Threading.Tasks;
                using Resources.Abstract;
                using Resources.Concrete;

                namespace {0} {{
                          public class {1} {{
                                 private static IResourceProvider resourceProvider = new {2}();
                          {3}
                              }}
                                }}"; // {0}: namespace {1}:class name   {2}:provider class name   {3}: body  

            const string property =
            @"
                {1}
                public static {2} {0} {{
                       get {{
                           return resourceProvider.GetResource(""{0}"", CultureInfo.CurrentUICulture.Name) as {2};
                       }}
                    }}"; // {0}: key

            #endregion


            // Store keys in a string builder
            var sbKeys = new StringBuilder();

            foreach (var key in keys)
            {
                var resource = resources.Where(r => (summaryCulture == null ? true : r.Culture.ToLowerInvariant() == summaryCulture.ToLowerInvariant())
                 && r.Name == key).FirstOrDefault();

                if (resource == null)
                {
                    throw new Exception(string.Format($"Could not find resource {key}"));
                }

                sbKeys.Append(new string(' ', 12)); // Indentation
                sbKeys.AppendFormat(property, key,
                    summaryCulture == null ? string.Empty : string.Format($"/// <summary>{resource.Value}</summary>"), resource.Type);
                sbKeys.AppendLine();
            }

            if (filePath == null)
            {
                filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Resources.cs");
            }

            // Write to file
            using (var writer = File.CreateText(filePath))
            {
                // Wrtier header go along keys
                writer.WriteLine(header, namespaceName, className, provider.GetType().Name, sbKeys.ToString());
                writer.Flush();
                writer.Close();
            }

            return filePath;
        }
    }
}
