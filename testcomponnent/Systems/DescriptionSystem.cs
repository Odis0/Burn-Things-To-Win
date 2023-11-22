using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burn_Things_To_Win
{
    public class DescriptionSystem : System
    {
        private Entity? player = null;
        public DescriptionSystem() : base() {
            AddRequiredComponent<RoomComp>();
        }

        public DescriptionSystem(Entity p) : base()
        {
            AddRequiredComponent<DescriptionComponent>();
            player = p;
        }

        public override void UpdateAll(float deltaTime)
        {
            if (player == null) return;
            PositionComponent playerLocation = player.GetComponent<PositionComponent>();
            
            if (playerLocation != null) {
                foreach (Entity entity in Entities)
                {
                    if (entity.HasComponent<RoomComp>()) {
                        if (entity.GetComponent<PositionComponent>().positionId == playerLocation.positionId)
                        {
                            Update(entity, deltaTime);
                        }
                    }
                    
                }

                foreach (Entity entity in Entities)
                {
                    if (!entity.HasComponent<RoomComp>())
                    {
                        if (entity.GetComponent<PositionComponent>().positionId == playerLocation.positionId)
                        {
                            Update(entity, deltaTime);
                        }
                    }
                }
            }
        }
        protected override void Update(Entity entity, float deltaTime)
        {
            DescriptionComponent dc = entity.GetComponent<DescriptionComponent>();
            Console.Out.WriteLine(dc.text);
        }
    }
}
