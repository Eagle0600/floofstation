using Content.Server.Humanoid;
using Content.Shared.Chemistry.Reagent;
using Content.Shared.Humanoid;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Server.FloofStation.Chemistry.ReagentEffects
{
    /// <summary>
    /// Sets the sex of the effected character.
    /// </summary>
    [UsedImplicitly]
    public sealed partial class SetSex : ReagentEffect
    {
        /// <summary>
        /// What sex to set
        /// </summary>
        [DataField("sex")]
        public Sex TargetSex { get; set; } = Sex.Unsexed;

        public override void Effect(ReagentEffectArgs args)
        {
            IEntityManager entMan = args.EntityManager;
            if (!entMan.TryGetComponent(args.SolutionEntity, out HumanoidAppearanceComponent? appearance))
                return;
            entMan.System<HumanoidAppearanceSystem>().SetSex(args.SolutionEntity, TargetSex, true, appearance);
        }

        protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
        => Loc.GetString("reagent-effect-guidebook-set-sex", ("sex", TargetSex));
    }
}
