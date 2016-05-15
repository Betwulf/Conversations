using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json;
using System.IO;
using ConversationsCore.Interfaces;

namespace ConversationsCore
{
    public class ConversationsClassRepository<T> where T : IRepositoryObject
    {

        private Dictionary<string, T> Cache;
        private readonly bool isCached;

        public string RootPath { get; set; }

        public string CollectionId
        { get { return this.GetType().GenericTypeArguments[0].FullName; } }

        public string ClassDirectory
        { get { return System.IO.Path.Combine(RootPath, CollectionId); } }

        private string GetFullFilename(string id)
        {
            return System.IO.Path.Combine(ClassDirectory, id + ".json");
        }

        public ConversationsClassRepository(bool createCache = true)
        {
            isCached = createCache;
            if (isCached)
            {
                Cache = new Dictionary<string, T>();
            }
            RootPath = ConfigurationManager.AppSettings["repository-rootpath"];
        }

        public async Task<T> SaveOrUpdateAsync(T entity)
        {
            await Task<T>.Run(() =>
           {
               Directory.CreateDirectory(ClassDirectory); // Create Directory if it isn't already made
               string filepathString = GetFullFilename(entity.Id);

               if (!File.Exists(filepathString))
               {
                   // Creating new item
                   File.WriteAllText(filepathString, JsonConvert.SerializeObject(entity));
                   if (isCached) Cache.Add(entity.Id, entity);
               }
               else
               {
                   // overwrite existing item
                   File.WriteAllText(filepathString, JsonConvert.SerializeObject(entity));
                   if (isCached)
                   {
                       Cache.Remove(entity.Id); // Overwrite cache
                       Cache.Add(entity.Id, entity);
                   }
               }
               return entity;
           });
            return entity;
        }



        public async Task DeleteAsync(string id)
        {
            await Task.Run(() =>
            {
                if (isCached) Cache.Remove(id);
                string filepathString = GetFullFilename(id);
                if (File.Exists(filepathString))
                {
                    File.Delete(filepathString);
                }
                else
                {
                    Console.WriteLine("File \"{0}\" did not exist.", filepathString);
                }
            });
        }

        public async Task DeleteAsync(T entity)
        {
            await DeleteAsync(entity.Id);
        }


        public IQueryable<T> GetAll()
        {
            var dir = new DirectoryInfo(ClassDirectory);
            IEnumerable<FileInfo> fileList = dir.GetFiles("*.json", SearchOption.AllDirectories);
            List<T> tempList = new List<T>();
            foreach (var item in fileList)
            {
                T storedDoc = default(T);
                T tempObject = default(T);
                // get the id from the filename
                var id = item.Name.Remove(item.Name.Length - item.Extension.Length);
                // Try to get the object from the cache
                if (isCached && Cache.TryGetValue(id, out storedDoc))
                {
                    tempObject = storedDoc;
                }
                else
                {
                    tempObject = JsonConvert.DeserializeObject<T>(File.ReadAllText(item.FullName));
                    if (isCached) Cache.Add(id, tempObject);
                }
                tempList.Add(tempObject);
            }
            return new EnumerableQuery<T>(tempList);
        }



        public T GetById(string id)
        {
            T storedDoc;
            if (isCached && Cache.TryGetValue(id, out storedDoc))
            {
                //Console.WriteLine("returning stored doc: " + id);
                return storedDoc;
            }
            Directory.CreateDirectory(ClassDirectory); // Create Directory if it isn't already made
            string pathString = GetFullFilename(id);
            if (File.Exists(pathString))
            {
                T theDoc = JsonConvert.DeserializeObject<T>(File.ReadAllText(pathString));
                if (isCached) Cache.Add(id, theDoc);
                return theDoc;
            }
            else
            {
                return default(T);
            }
        }


    }
}
