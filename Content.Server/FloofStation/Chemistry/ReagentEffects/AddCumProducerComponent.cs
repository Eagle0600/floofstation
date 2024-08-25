using Content.Server.FloofStation.Traits;
using Content.Shared.Chemistry.Reagent;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Server.FloofStation.Chemistry.ReagentEffects
{
    /// <summary>
    /// Give the affected character the ability to cum.
    /// </summary>
    [UsedImplicitly]
    public sealed partial class AddCumProducerComponent: ReagentEffect
    {
        /// <summary>
        /// Initial fill level.
        /// </summary>
        [DataField("fill")]
        public float InitialFill { get; set; } = 1f;

        public override void Effect(ReagentEffectArgs args)
        {
            IEntityManager entMan = args.EntityManager;
            EntityUid uid = args.SolutionEntity;
            if (entMan.HasComponent<CumProducerComponent>(uid))
                return;
            entMan.AddComponent<CumProducerComponent>(uid);
        }

        protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => Loc.GetString("reagent-effect-guidebook-add-body-part", ("part", "penis"));
    }
}
