using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burn_Things_To_Win
{
    public class Manager
    {
        private Dictionary<int, Entity> entities;
        private Dictionary<Type, System> systems;
        private List<int> toDelete;
        private int currentId = 0;

        public Manager()
        {
            entities = new Dictionary<int, Entity>();
            systems = new Dictionary<Type, System>();
            toDelete = new List<int>();
        }

        public Entity AddAndGetEntity()
        {
            Entity entity = new Entity(currentId++);
            entities[entity.Id] = entity;
            return entity;
        }

        public void DeleteEntity(int id)
        {
            toDelete.Add(id);
        }


        public void AddComponentToEntity(Entity entity, Component component)
        {
            entity.AddComponent(component);
            UpdateEntityRegistration(entity);
        }

        public void RemoveComponentFromEntity<T>(Entity entity) where T : Component
        {
            entity.RemoveComponent<T>();
            UpdateEntityRegistration(entity);
        }
        private void UpdateEntityRegistration(Entity entity)
        {
            foreach (System system in systems.Values)
            {
                system.UpdateEntityRegistration(entity);
            }
        }
        public T GetSystem<T>() where T : System
        {
            return (T)systems[typeof(T)];
        }
        public void AddSystem(System system)
        {
            systems[system.GetType()] = system;
            system.BindManager(this);
        }
        public Entity GetEntityById(int id)
        {
            return entities[id];
        }


        public void Update(float deltaTime)
        {
            foreach (System system in systems.Values)
            {
                system.UpdateAll(deltaTime);
            }
            Flush();
        }

        private void Flush()
        {
            foreach (int id in toDelete)
            {
                if (!EntityExists(id)) //safeguard against deleting twice
                    continue;

                foreach (System system in systems.Values)
                {
                    system.DeleteEntity(id);
                }

                entities.Remove(id);
            }
            toDelete.Clear();
        }

        public bool EntityExists(int id)
        {
            return entities.ContainsKey(id);
        }
    }
}
