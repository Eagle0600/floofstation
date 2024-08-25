using Content.Server.Chemistry.Containers.EntitySystems;
using Content.Server.FloofStation.Traits;
using Content.Shared.Chemistry.Components.SolutionManager;
using Content.Shared.Chemistry.Reagent;
using Content.Shared.Chemistry.EntitySystems;
using FastAccessors;
using JetBrains.Annotations;
using Robust.Shared.GameObjects;
using Robust.Shared.Prototypes;
using Content.Shared.Chemistry.Components;

namespace Content.Server.FloofStation.Chemistry.ReagentEffects
{
    /// <summary>
    /// Removes the ability of the effected character to cum.
    /// </summary>
    [UsedImplicitly]
    public sealed partial class RemoveCumProducerComponent: ReagentEffect
    {
        public override void Effect(ReagentEffectArgs args)
        {
            IEntityManager entMan = args.EntityManager;
            EntityUid uid = args.SolutionEntity;
            if (entMan.TryGetComponent(uid, out CumProducerComponent? cumProducerComp))
            {
                entMan.RemoveComponent(uid, cumProducerComp);
            }
        }

        protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => Loc.GetString("reagent-effect-guidebook-remove-body-part", ("part", "penis"));
    }
}
