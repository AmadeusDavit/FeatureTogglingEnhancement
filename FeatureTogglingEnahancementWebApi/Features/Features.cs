
using FeatureTogglingEnahancementWebApi.Interfaces;

namespace FeatureTogglingEnahancementWebApi.Features
{
    public class FinalizationFeature : ToggleFeature
    {
        public bool IsOn { get; set; }
        //public IList<ToggleFeature>? ChildFeatures { get; set; }
        //public ToggleFeature Parent { get; set; }
    }
    public class ScheduleModifyFeature : ToggleFeature { public bool IsOn { get; set; } }

    public class ScheduleDisplayModesFeature : ToggleFeature { public bool IsOn { get; set; } }

    public class ScheduleCodeshareFeature : ToggleFeature { public bool IsOn { get; set; } }

    public class ScheduleQuickSearchFeature : ToggleFeature { public bool IsOn { get; set; } }

    public class ScheduleTurnBuilderFeature : ToggleFeature { public bool IsOn { get; set; } }

    public class ScheduleStaticReportsFeature : ToggleFeature { public bool IsOn { get; set; } }

    public class ScheduleTimeZoneFeature : ToggleFeature { public bool IsOn { get; set; } }

    public class ScheduleContextMenuFeature : ToggleFeature { public bool IsOn { get; set; } }

    public class ScheduleBalanceViewFeature : ToggleFeature { public bool IsOn { get; set; } }

    public class ExtendACRegistrationEndOfRouteFeature : ToggleFeature { public bool IsOn { get; set; } }
}
