using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Blueprinter.Core.Data
{
    public abstract class JsonRepository<TEntity> : IRepository<TEntity>
    {
        protected readonly List<TEntity> Records;
        protected readonly string Path;

        public int Count => Records.Count;

        public JsonRepository(string path)
        {
            Records = new List<TEntity>();
            Path = path;
            ReadFile();
        }

        protected virtual Predicate<TEntity> CreatePredicateFrom(Expression<Func<TEntity, bool>> expression)
        {
            return new Predicate<TEntity>(expression.Compile());
        }

        protected virtual void WriteFile()
        {
            var json = JsonConvert.SerializeObject(Records);

            using (var writer = new StreamWriter(Path, false))
            {
                writer.Write(json);
            }
        }

        protected virtual void ReadFile()
        {
            var content = string.Empty;

            if (File.Exists(Path))
            {
                content = File.ReadAllText(Path);
            }

            if (string.IsNullOrWhiteSpace(content))
            {
                return;
            }
            var records = JsonConvert.DeserializeObject<List<TEntity>>(content);
                Records.Clear();
                Records.AddRange(records);
        }

        public IEnumerable<TEntity> All()
        {
            return Records.ToArray();
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            var func = predicate.Compile();
            return Records.Any(func);
        }

        public abstract TEntity Create(TEntity t);

        public abstract int Delete(TEntity t);

        public int Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var pred = CreatePredicateFrom(predicate);
            return Records.RemoveAll(pred);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            var pred = CreatePredicateFrom(predicate);
            return Records.Find(pred);
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            var pred = CreatePredicateFrom(predicate);
            return Records.FindAll(pred);
        }

        public abstract int Update(TEntity t);
    }
}
