using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wooff.ECS.Entities;

namespace Wooff.ECS.Contexts 
{
    public class EntityContext : 
        IContext<IEntity>, 
        IContextQueryable<IEntity>,
        IContextQueryable<Type>
    {
        private readonly List<IEntity> _entities;
        private readonly Dictionary<Type, List<IEntity>> _componentToEntitiesDictionary;

        public EntityContext(params IEntity[] entities)
        {
            _entities = new List<IEntity>();
            _componentToEntitiesDictionary = new Dictionary<Type, List<IEntity>>();
            
            foreach (var entity in entities)
                ContextAdd(entity);
        }

        public IEntity ContextAdd(IEntity entity)
        {
            _entities.Add(entity);
            foreach (var componentType in entity.ContextSelectQuery(x => x.GetType()))
            {
                if(_componentToEntitiesDictionary.ContainsKey(componentType))
                    _componentToEntitiesDictionary[componentType].Add(entity);
                else
                    _componentToEntitiesDictionary.Add(componentType, new List<IEntity>
                    {
                        entity
                    });
            }

            return entity;
        }

        public T1? ContextGet<T1>() where T1 : class, IEntity
        {
            return _entities.FirstOrDefault(x => x.GetType().IsAssignableFrom(typeof(T1))) as T1;
        }

        public bool ContextContains<T1>() where T1 : class, IEntity
        {
            return _entities.Any(x => x.GetType().IsAssignableFrom(typeof(T1)));
        }

        public bool ContextRemove(IEntity entity)
        {
            foreach (var component in entity.ContextWhereQuery(
                         x => _componentToEntitiesDictionary.ContainsKey(x.GetType())))
                _componentToEntitiesDictionary[component.GetType()].Remove(entity);
            
            return _entities.Remove(entity);
        }

        public IQueryable<T1> ContextSelectQuery<T1>(Func<IEntity, T1> query)
        {
            return _entities
                .Select(query.Invoke)
                .AsQueryable();
        }

        public IEnumerable<IEntity> ContextWhereQuery(Func<IEntity, bool> query)
        {
            return _entities
                .Where(query.Invoke);
        }

        IContextQueryable<IEntity> IContextQueryable<IEntity>.CreateEmptySelf()
        {
            return new EntityContext();
        }

        public IQueryable<T1> ContextSelectQuery<T1>(Func<Type, T1> query)
        {
            return _componentToEntitiesDictionary
                .Select(x => query.Invoke(x.Key))
                .AsQueryable();
        }

        public IEnumerable<Type> ContextWhereQuery(Func<Type, bool> query)
        {
            return _componentToEntitiesDictionary
                .Where(x => query.Invoke(x.Key))
                .Select(x => x.Key);
        }

        IContextQueryable<Type> IContextQueryable<Type>.CreateEmptySelf()
        {
            return new EntityContext();
        }

        IEnumerator<Type> IEnumerable<Type>.GetEnumerator()
        {
            return _componentToEntitiesDictionary.Select(x => x.Key).GetEnumerator();
        }

        IEnumerator<IEntity> IEnumerable<IEntity>.GetEnumerator()
        {
            return _entities.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _entities.GetEnumerator();
        }
    }
}