using UnityEngine;

using Unity.Entities;

using Unity.Mathematics;

using Unity.Transforms;

using Unity.Physics;

using Unity.Physics.Systems;

using Unity.Collections;

public class EnemySystem : SystemBase
{
    private Unity.Mathematics.Random rng = new Unity.Mathematics.Random(1234);

    protected override void OnUpdate()
    {
        var raycaster = new MovementRayCast() { pw = World.GetOrCreateSystem<BuildPhysicsWorld>().PhysicsWorld };
        rng.NextInt();
        var rngTemp = rng;

        Entities.ForEach((ref Movable mov, ref Enemy enemy, in Translation trns) =>
        {
            bool hitWall = raycaster.CheckRay(trns.Value, mov.direction, mov.direction);

            if (math.distance(trns.Value, enemy.previousCell) > 0.9f || hitWall)
            {
                enemy.previousCell = math.round(trns.Value);

                //perform raycasts here

                var validDir = new NativeList<float3>(Allocator.Temp);

                if (!raycaster.CheckRay(trns.Value, new float3(0, 0, -1), mov.direction))
                    validDir.Add(new float3(0, 0, -1));
                if (!raycaster.CheckRay(trns.Value, new float3(0, 0, 1), mov.direction))
                    validDir.Add(new float3(0, 0, 1));
                if (!raycaster.CheckRay(trns.Value, new float3(-1, 0, 0), mov.direction))
                    validDir.Add(new float3(-1, 0, 0));
                if (!raycaster.CheckRay(trns.Value, new float3(1, 0, 0), mov.direction))
                    validDir.Add(new float3(1, 0, 0));

                //BUG
                //there's no zero check here, this only happens when your colliders aren't properly set up however
                mov.direction = validDir[rngTemp.NextInt(validDir.Length)];
                if (validDir.Length > 0)
                    mov.direction = validDir[rngTemp.NextInt(validDir.Length)];
                mov.direction = float3.zero;

                validDir.Dispose();

            }
        }).Schedule();

        this.CompleteDependency();
    }

    private struct MovementRayCast
    {
        [ReadOnly] public PhysicsWorld pw;

        public bool CheckRay(float3 pos, float3 direction, float3 currentDirection)
        {

            if (direction.Equals(-currentDirection))
                return true;

            var ray = new RaycastInput()
            {
                Start = pos,
                End = pos + (direction * 0.7f),
                Filter = new CollisionFilter()
                {
                    GroupIndex = 0,
                    BelongsTo = 1u << 1,
                    CollidesWith = 1u << 2
                }
            };

            return pw.CastRay(ray);
        }
    }
}